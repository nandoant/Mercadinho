using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mercadinho.Model;
using Mercadinho.Repository;
using Mercadinho.View;

namespace Mercadinho.Presenter
{
    public class ClientePresenter
    {
        private IClienteRepository repository;
        private IClienteView view;
        private IVendaRepository vendaRepository;
        private List<Cliente> clientes;
        private const int ItensPorPagina = 10;

        public ClientePresenter(IClienteRepository repository, IClienteView view, IVendaRepository vendaRepository)
        {
            this.repository = repository;
            this.vendaRepository = vendaRepository;
            this.view = view;

            ConfigurarEventos();
            CarregarClientes();
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
            view.EditarCliente += HandleEditar;
            view.ExcluirCliente += HandleExcluir;
        }

        private void CarregarClientes()
        {
            clientes = repository.Listar().ToList();
            AtualizarPaginacao();
        }

        private void AtualizarPaginacao()
        {
            var paginaAtual = view.Pagina;
            var totalPaginas = (int)Math.Ceiling(clientes.Count / (double)ItensPorPagina);

            var clientesPagina = clientes
                .Skip((paginaAtual - 1) * ItensPorPagina)
                .Take(ItensPorPagina)
                .ToList();

            view.DisplayClientes(clientesPagina);
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

        private void HandleEditar(object sender, int clienteId)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == clienteId);
            if (cliente != null)
            {
                view.PreencherCampos(cliente);
                view.MostrarDetalhes();
            }
        }

        private void HandleExcluir(object sender, int clienteId)
        {
            try
            {
                var vendasCliente = vendaRepository.ObterPorCliente(clienteId);
                if (vendasCliente.Any())
                {
                    MessageBox.Show("Não é possível excluir o cliente pois existem vendas vinculadas a ele.", 
                                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Não recarrega a lista aqui!
                }

                repository.Remover(clienteId);
                CarregarClientes(); // Recarrega APÓS a exclusão
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandlePesquisar(object sender, EventArgs e)
        {
            String termo = view.BarraDePesquisa;
            if (string.IsNullOrEmpty(termo))
            {
                CarregarClientes();
                return;
            }

            clientes = repository.ObterPorvalor(termo).ToList();
            view.Pagina = 1;
            AtualizarPaginacao();
        }

        private void HandleSalvar(object sender, EventArgs e)
        {
            try
            {
                var cliente = view.ObterClienteDoFormulario();
                ValidarCliente(cliente);
                if (cliente.Id == 0)
                {
                    repository.Adicionar(cliente);
                }
                else
                {
                    repository.Atualizar(cliente);
                }

                CarregarClientes();
                view.MostrarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar cliente: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome.Trim()))
            {
                throw new Exception("Nome do cliente é obrigatório");
            }

            if (cliente.Nome.Any(char.IsDigit) || cliente.Nome.Any(ch => !char.IsLetter(ch) && !char.IsWhiteSpace(ch)))
            {
                throw new Exception("Nome do cliente não pode conter números ou caracteres especiais");
            }

            if (cliente.Idade <= 0)
            {
                throw new Exception("Idade deve ser maior que zero");
            }

            if (cliente.Idade > 190)
            {
                throw new Exception("Idade deve ser menor que 190");
            }

            if (string.IsNullOrEmpty(cliente.Cpf.Trim()))
            {
                throw new Exception("CPF do cliente é obrigatório");
            }

            if (cliente.Cpf.Length != 11)
            {
                throw new Exception("CPF deve conter 11 dígitos");
            }

            if (!cliente.Cpf.All(char.IsDigit))
            {
                throw new Exception("CPF deve conter apenas números");
            }

            if (repository.ObterPorCpf(cliente.Cpf) != null)
            {
                throw new Exception("CPF já cadastrado");
            }
        }

        private void HandleCancelar(object sender, EventArgs e)
        {
            view.MostrarLista();
        }

        private void HandleAvancarPagina(object sender, EventArgs e)
        {
            var totalPaginas = (int)Math.Ceiling(clientes.Count / (double)ItensPorPagina);
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