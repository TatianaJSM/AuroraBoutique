using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IEstadoBL
    {
        void Insertar(Estado estado);
        void Modificar(Estado estado);
        void Eliminar(int idEstado);
        IEnumerable<Estado> Listar();

    }
}
