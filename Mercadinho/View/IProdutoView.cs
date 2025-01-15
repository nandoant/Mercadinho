using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercadinho.Model;

namespace Mercadinho.View
{
    public interface IProdutoView
    {

        // Properties
        string BarraDePesquisa { get; set; }
        int Pagina { get; set; }

        // Events
        event EventHandler Adicionar;
        event EventHandler Pesquisar;
        event EventHandler AvancarPagina;
        event EventHandler VoltarPagina;
        event EventHandler Salvar;
        event EventHandler Cancelar;
        event EventHandler<int> EditarProduto;
        event EventHandler<int> ExcluirProduto;
        event EventHandler FecharJanela;

        // Display Methods
        void DisplayProdutos(List<Produto> produtos);
        void AtualizarBotoesPaginacao(bool temProximaPagina, bool temPaginaAnterior);

        // Form Operation Methods
        void MostrarDetalhes();
        void MostrarLista();
        void LimparCampos();
        void PreencherCampos(Produto produto);
        Produto ObterProdutoDoFormulario();

        // Form Methods
        void Show();

    }
}
