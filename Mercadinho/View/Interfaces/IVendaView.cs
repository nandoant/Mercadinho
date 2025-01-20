using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;

namespace Mercadinho.View.Interfaces
{

    public interface IVendaMainView
    {
        void MostrarListaVendas();
        void MostrarSelecaoCliente();
        void MostrarProdutos();
        Cliente ClienteSelecionado { get; set; }
    }


    public interface ISelecaoClienteView
    {
        string TextoPesquisa { get; set; }
        int PaginaAtual { get; set; }

        event EventHandler Pesquisar;
        event EventHandler ProximaPagina;
        event EventHandler PaginaAnterior;
        event EventHandler<Cliente> OnClienteSelecionado;

        void AtualizarPaginacaoClientes(bool temProxima, bool temAnterior);
        void ExibirClientes(List<Cliente> clientes);
        void AtualizarPaginacao(bool temProxima, bool temAnterior);
    }

    public interface IProdutoCarrinhoView
    {
        string TextoPesquisa { get; set; }
        int PaginaAtual { get; set; }
        bool VisualizacaoCarrinho { get; set; }

        event EventHandler Pesquisar;
        event EventHandler ProximaPagina;
        event EventHandler PaginaAnterior;
        event EventHandler AlternarVisualizacao;
        event EventHandler<Produto> AdicionarAoCarrinho;
        event EventHandler<Produto> RemoverDoCarrinho;

        void ExibirProdutos(List<Produto> produtos);
        void ExibirCarrinho(List<Produto> itensCarrinho);
        void AtualizarPaginacao(bool temProxima, bool temAnterior);
    }
}
