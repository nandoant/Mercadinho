using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;

namespace Mercadinho.View.Interfaces
{
    public interface IListaVendaView
    {
        string TextoPesquisa { get; set; }
        int PaginaAtual { get; set; }

        event EventHandler Pesquisar;
        event EventHandler ProximaPagina;
        event EventHandler PaginaAnterior;
        event EventHandler NovaVenda;
        event EventHandler<int> DeletarVenda;
        event EventHandler VerProdutos;
        event EventHandler VendaFinalizada;

        void ExibirVendas(List<Venda> vendas);
        void AtualizarPaginacao(bool temProxima, bool temAnterior);
        void Show();
    }
}
