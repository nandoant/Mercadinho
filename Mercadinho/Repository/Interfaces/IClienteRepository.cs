using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;

namespace Mercadinho.Repository
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        void Atualizar(Cliente cliente);
        void Remover(int id);
        Cliente ObterPorCpf(string cpf);
        IEnumerable<Cliente> Listar();
        IEnumerable<Cliente> ObterPorvalor(string valor);
        Cliente ObterPorCpfExcetoId(string cpf, int id);
    }
}
