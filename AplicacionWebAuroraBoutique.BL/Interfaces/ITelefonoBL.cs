using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ITelefonoBL
    {
        void Insertar(Telefono telefono);
        void Modificar(Telefono telefono);
        void Eliminar(int idTelefono);
        IEnumerable<Telefono> Listar();
    }
}
