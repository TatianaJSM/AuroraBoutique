using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IClienteBL
    {
        void Insertar(Cliente c);
        void Modificar(Cliente c);
        void Eliminar(int idCliente);
        IEnumerable<Cliente> Listar();
    }
}
