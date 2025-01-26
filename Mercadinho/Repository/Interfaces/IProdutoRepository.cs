using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;

namespace Mercadinho.Repository
{
    public interface IProdutoRepository
    {
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(int id);
        Produto ObterPorId(int id);
        IEnumerable<Produto> Listar();
        IEnumerable<Produto> ObterPorvalor(string valor);
    }
}
