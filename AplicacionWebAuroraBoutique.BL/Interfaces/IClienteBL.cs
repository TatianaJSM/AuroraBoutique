using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IClienteBL
    {
        void RegistrarCliente();
        void ModificarCliente();
        void EliminarCliente();
        void ListarClientes();
    }
}
