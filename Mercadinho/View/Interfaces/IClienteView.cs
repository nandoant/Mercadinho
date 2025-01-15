using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;

namespace Mercadinho.View
{
    public interface IClienteView
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
        event EventHandler<int> EditarCliente;
        event EventHandler<int> ExcluirCliente;

        // Display Methods
        void DisplayClientes(List<Cliente> clientes);
        void AtualizarBotoesPaginacao(bool temProximaPagina, bool temPaginaAnterior);

        // Form Operation Methods
        void MostrarDetalhes();
        void MostrarLista();
        void LimparCampos();
        void PreencherCampos(Cliente cliente);
        Cliente ObterClienteDoFormulario();

        // Form Methods
        void Show();
    }
}
