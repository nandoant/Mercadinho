using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.GRIDs
{
    public  interface ILstCliente
    {
        int Id { get; set; }
        string Name { get; set; }
        int Idade { get; set; }
        string Cpf { get; set; }
        // Events
        event EventHandler Editar;
        event EventHandler Excluir;
    }
}
