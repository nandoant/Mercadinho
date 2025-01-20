using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercadinho.Model;

namespace Mercadinho.Repository.Interfaces
{
    public interface IVendaProdutoRepository
    {
        void AdicionarItens(int vendaId, IEnumerable<Model.VendaProduto> itens);
        IEnumerable<VendaProduto> ObterPorVenda(int vendaId);
        void RemoverItensVenda(int vendaId);

    }
}
