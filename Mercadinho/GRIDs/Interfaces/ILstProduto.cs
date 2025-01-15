using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.GRIDs
{
    public interface ILstProduto
    {
        // Properties
        int Id { get; set; }
        string Nome { get; set; }
        double Preco { get; set; }
        string Descricao { get; set; }
        string Marca { get; set; }
        string Modelo { get; set; }

        // Events
        event EventHandler Editar;
        event EventHandler Excluir;
    }
}
