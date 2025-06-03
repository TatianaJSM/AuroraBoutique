using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IDireccionBL
    {
        void Insertar(Direccion d);
        void Modificar(Direccion d);
        void Eliminar(int idDireccion);
        IEnumerable<Direccion> Listar();
    }
}
