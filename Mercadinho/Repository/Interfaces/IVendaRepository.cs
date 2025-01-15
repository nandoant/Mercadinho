using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;

namespace Mercadinho.Repository
{
    public interface IVendaRepository
    {
        void Adicionar(Venda venda);
        IEnumerable<Venda> Listar();
        IEnumerable<Venda> ObterPorCliente(int idCliente);
        IEnumerable<Venda> ObterPorPeriodo(DateTime inicio, DateTime fim);
        void Remover(int id);
    }
}
