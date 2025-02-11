﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mercadinho.GRIDs;
using Mercadinho.Model;
using Mercadinho.Repository;
using Mercadinho.Repository.Interfaces;
using Mercadinho.View.Interfaces;
using Mercadinho.View;

namespace Mercadinho.Presenter
{
    public class VendaListPresenter
    {
        private IVendaRepository vendaRepo;
        private IClienteRepository clienteRepo;
        private IProdutoRepository produtoRepo;
        private IVendaProdutoRepository vendaProdutoRepo;
        private IListaVendaView view;
        private List<Venda> vendas;
        private const int ItensPorPagina = 10;
        public event EventHandler NovaVendaClick;


        public VendaListPresenter(IListaVendaView view, IVendaRepository vendaRepo, IClienteRepository clienteRepo)
        {
            this.view = view;
            this.vendaRepo = vendaRepo;
            this.clienteRepo = clienteRepo;
            this.produtoRepo = new ProdutoRepository();
            this.vendaProdutoRepo = new VendaProdutoRepository();
            this.vendas = new List<Venda>();

            ConfigurarEventos();
            CarregarVendas();
            view.Show();
        }

        private void ConfigurarEventos()
        {
            view.Pesquisar += HandlePesquisar;
            view.ProximaPagina += HandleProximaPagina;
            view.PaginaAnterior += HandlePaginaAnterior;
            view.DeletarVenda += HandleDeletarVenda;
            view.NovaVenda += HandleNovaVenda;
            view.VerProdutos += HandleVerProdutos;
            view.VendaFinalizada += (s, e) => CarregarVendas();
        }

        private void HandleNovaVenda(object sender, EventArgs e)
        {
            NovaVendaClick?.Invoke(this, EventArgs.Empty);
        }

        private void CarregarProdutosECalcularTotal(List<Venda> vendas)
        {
            foreach (var venda in vendas)
            {
                venda.Produtos = new List<Produto>();
                var vendaProdutos = vendaProdutoRepo.ObterPorVenda(venda.Id).ToList();
                
                foreach (var vendaProduto in vendaProdutos)
                {
                    var produto = produtoRepo.ObterPorvalor(vendaProduto.ProdutoId.ToString()).FirstOrDefault();
                    if (produto != null)
                    {
                        var produtoVenda = new Produto
                        {
                            Id = produto.Id,
                            Nome = produto.Nome,
                            PrecoUnitario = vendaProduto.PrecoUnitario,
                            Descricao = produto.Descricao,
                            Marca = produto.Marca,
                            Modelo = produto.Modelo,
                            QuantidadeEmEstoque = vendaProduto.Quantidade
                        };
                        venda.Produtos.Add(produtoVenda);
                    }
                }
                
                venda.ValorTotal = vendaProdutos.Sum(vp => vp.CalcularSubtotal());
            }
        }

        private void CarregarVendas()
        {
            try
            {
                vendas = vendaRepo.ListarVendas().ToList();
                CarregarProdutosECalcularTotal(vendas);
                AtualizarPaginacao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar vendas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarPaginacao()
        {
            var paginaAtual = view.PaginaAtual;
            var totalPaginas = (int)Math.Ceiling(vendas.Count / (double)ItensPorPagina);

            var vendasPagina = vendas
                .Skip((paginaAtual - 1) * ItensPorPagina)
                .Take(ItensPorPagina)
                .ToList();

            view.ExibirVendas(vendasPagina);
            view.AtualizarPaginacao(
                temProxima: paginaAtual < totalPaginas,
                temAnterior: paginaAtual > 1
            );
        }

        private void HandlePesquisar(object sender, EventArgs e)
        {
            try
            {
                var termo = view.TextoPesquisa?.Trim();
                if (string.IsNullOrEmpty(termo))
                {
                    CarregarVendas();
                    return;
                }

                if (int.TryParse(termo, out int id))
                {
                    vendas = vendaRepo.ListarVendas()
                        .Where(v => v.Id == id)
                        .ToList();
                }
                else
                {
                    var clientesEncontrados = clienteRepo.Listar()
                        .Where(c => c.Nome.IndexOf(termo, StringComparison.OrdinalIgnoreCase) >= 0)
                        .Select(c => c.Id);

                    vendas = vendaRepo.ListarVendas()
                        .Where(v => clientesEncontrados.Contains(v.IdCliente))
                        .ToList();
                }

                CarregarProdutosECalcularTotal(vendas);
                view.PaginaAtual = 1;
                AtualizarPaginacao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao pesquisar vendas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleDeletarVenda(object sender, int vendaId)
        {
            var result = MessageBox.Show(
                "Deseja realmente excluir esta venda?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    vendaRepo.Remover(vendaId);
                    CarregarVendas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir venda: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void HandleProximaPagina(object sender, EventArgs e)
        {
            var totalPaginas = (int)Math.Ceiling(vendas.Count / (double)ItensPorPagina);
            if (view.PaginaAtual < totalPaginas)
            {
                view.PaginaAtual++;
                AtualizarPaginacao();
            }
        }

        private void HandlePaginaAnterior(object sender, EventArgs e)
        {
            if (view.PaginaAtual > 1)
            {
                view.PaginaAtual--;
                AtualizarPaginacao();
            }
        }

        private void HandleVerProdutos(object sender, EventArgs e)
        {
            try
            {
                var lstVenda = sender as LstVenda;
                if (lstVenda == null) return;

                var vendaId = lstVenda.Id;
                var vendaProdutos = vendaProdutoRepo.ObterPorVenda(vendaId).ToList();
                
                if (!vendaProdutos.Any())
                {
                    MessageBox.Show("Não há produtos registrados para esta venda.", 
                        "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var produtosIds = vendaProdutos.Select(vp => vp.ProdutoId).ToList();
                var produtos = produtosIds
                    .SelectMany(id => produtoRepo.ObterPorvalor(id.ToString()))
                    .ToList();

                var formProdutos = new VendaProdutoView();
                formProdutos.Text = $"Produtos da Venda #{vendaId}";
                formProdutos.ExibirProdutos(vendaProdutos, produtos);
                formProdutos.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}