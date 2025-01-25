using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercadinho.GRIDs;
using Mercadinho.Model;
using Mercadinho.Repository;
using Mercadinho.View;
using MySql.Data.MySqlClient;

namespace Mercadinho.Presenter
{
    public class ProdutoPresenter
    {
        private readonly IProdutoRepository repository;
        private readonly IProdutoView view;
        private List<Produto> produtos;
        private const int ItensPorPagina = 10;

        public ProdutoPresenter(IProdutoRepository repository, IProdutoView view)
        {
            this.repository = repository;
            this.view = view;

            ConfigurarEventos();
            CarregarProdutos();
            view.Show();
        }

        private void ConfigurarEventos()
        {
            view.Adicionar += HandleAdicionar;
            view.Pesquisar += HandlePesquisar;
            view.AvancarPagina += HandleAvancarPagina;
            view.VoltarPagina += HandleVoltarPagina;
            view.Salvar += HandleSalvar;
            view.Cancelar += HandleCancelar;
            view.EditarProduto += HandleEditar;
            view.ExcluirProduto += HandleExcluir;
        }

        private void CarregarProdutos()
        {
            produtos = repository.Listar().ToList();
            AtualizarPaginacao();
        }

        private void AtualizarPaginacao()
        {
            var paginaAtual = view.Pagina;
            var totalPaginas = (int)Math.Ceiling(produtos.Count / (double)ItensPorPagina);

            var produtosPagina = produtos
                .Skip((paginaAtual - 1) * ItensPorPagina)
                .Take(ItensPorPagina)
                .ToList();

            view.DisplayProdutos(produtosPagina);
            view.AtualizarBotoesPaginacao(
                temProximaPagina: paginaAtual < totalPaginas,
                temPaginaAnterior: paginaAtual > 1
            );
        }

        private void HandleAdicionar(object sender, EventArgs e)
        {
            view.LimparCampos();
            view.MostrarDetalhes();
        }

        private void HandleEditar(object sender, int produtoId)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == produtoId);
            if (produto != null)
            {
                view.PreencherCampos(produto);
                view.MostrarDetalhes();
            }
        }

        private void HandleExcluir(object sender, int produtoId)
        {
            try
            {
                repository.Remover(produtoId);
                CarregarProdutos();
            }
            catch (MySqlException ex) when (ex.Number == 1451) // Código de erro para restrição de FK
            {
                MessageBox.Show("Não é possível excluir este produto pois ele está vinculado a uma ou mais vendas.", 
                    "Erro de integridade", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir produto: {ex.Message}", 
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandlePesquisar(object sender, EventArgs e)
        {
            var termo = view.BarraDePesquisa;
            if (string.IsNullOrEmpty(termo))
            {
                CarregarProdutos();
                return;
            }

            produtos = repository.ObterPorvalor(termo).ToList();
            view.Pagina = 1;
            AtualizarPaginacao();
        }

        private void HandleSalvar(object sender, EventArgs e)
        {
            try
            {
                var produto = view.ObterProdutoDoFormulario();
                ValidarProduto(produto);
                if (produto.Id == 0)
                {
                    repository.Adicionar(produto);
                }
                else
                {
                    repository.Atualizar(produto);
                }

                CarregarProdutos();
                view.MostrarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar produto: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarProduto(Produto produto)
        {
            if (string.IsNullOrEmpty(produto.Nome.Trim()))
            {
                throw new Exception("Nome do produto é obrigatório");
            }

            if (double.TryParse(produto.PrecoUnitario.ToString(), out double preco) == false)
            {
                throw new Exception("Preço do produto deve ser um número");
            }

            if (produto.PrecoUnitario <= 0)
            {
                throw new Exception("Preço do produto deve ser maior que zero");
            }

            if (string.IsNullOrEmpty(produto.Marca.Trim()))
            {
                throw new Exception("Marca do produto é obrigatória");
            }

            if (string.IsNullOrEmpty(produto.Modelo.Trim()))
            {
                throw new Exception("Modelo do produto é obrigatório");
            } 
        }

        private void HandleCancelar(object sender, EventArgs e)
        {
            view.MostrarLista();
        }

        private void HandleAvancarPagina(object sender, EventArgs e)
        {
            var totalPaginas = (int)Math.Ceiling(produtos.Count / (double)ItensPorPagina);
            if (view.Pagina < totalPaginas)
            {
                view.Pagina++;
                AtualizarPaginacao();
            }
        }

        private void HandleVoltarPagina(object sender, EventArgs e)
        {
            if (view.Pagina > 1)
            {
                view.Pagina--;
                AtualizarPaginacao();
            }
        }
    }
}
