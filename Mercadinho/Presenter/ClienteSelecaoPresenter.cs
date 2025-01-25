using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Mercadinho.Model;
using Mercadinho.Repository;
using Mercadinho.View.Interfaces;

public class ClienteSelecaoPresenter
{
    private readonly IClienteRepository clienteRepo;
    private readonly ISelecaoClienteView view;
    private readonly IVendaMainView mainView;
    private List<Cliente> clientes;
    private const int ItensPorPagina = 10;

    public ClienteSelecaoPresenter(
        ISelecaoClienteView view, 
        IVendaMainView mainView, 
        IClienteRepository clienteRepo)
    {
        this.view = view;
        this.mainView = mainView;
        this.clienteRepo = clienteRepo;
        this.clientes = new List<Cliente>();

        ConfigurarEventos();
        CarregarClientes();
    }

    public void RecarregarClientes()
    {
        CarregarClientes();
    }
    private void ConfigurarEventos()
    {
        view.Pesquisar += HandlePesquisar;
        view.ProximaPagina += HandleProximaPagina;
        view.PaginaAnterior += HandlePaginaAnterior;
        view.OnClienteSelecionado += HandleClienteSelecionado;
    }

    private void CarregarClientes()
    {
        try
        {
            clientes = clienteRepo.Listar().ToList();
            view.PaginaAtual = 1;
            AtualizarPaginacao();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void AtualizarPaginacao()
    {
        var paginaAtual = view.PaginaAtual;
        var totalPaginas = (int)Math.Ceiling(clientes.Count / (double)ItensPorPagina);

        var clientesPagina = clientes
            .Skip((paginaAtual - 1) * ItensPorPagina)
            .Take(ItensPorPagina)
            .ToList();

        view.ExibirClientes(clientesPagina);
        view.AtualizarPaginacaoClientes(
            temProxima: paginaAtual < totalPaginas,
            temAnterior: paginaAtual > 1
        );
    }

    private void HandlePesquisar(object sender, EventArgs e)
    {
        var termo = view.TextoPesquisa?.Trim();
        if (string.IsNullOrEmpty(termo))
        {
            CarregarClientes();
            return;
        }

        clientes = clienteRepo.Listar()
            .Where(c => 
                c.Nome.Contains(termo) || 
                (int.TryParse(termo, out int id) && c.Id == id))
            .ToList();

        view.PaginaAtual = 1;
        AtualizarPaginacao();
    }

    private void HandleProximaPagina(object sender, EventArgs e)
    {
        var totalPaginas = (int)Math.Ceiling(clientes.Count / (double)ItensPorPagina);
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

    private void HandleClienteSelecionado(object sender, Cliente cliente)
    {
        mainView.ClienteSelecionado = cliente;
        mainView.MostrarProdutos();
    }
}