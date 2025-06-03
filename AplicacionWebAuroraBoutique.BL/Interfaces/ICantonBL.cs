using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ICantonBL
    {
        void Insertar(Canton canton);
        void Modificar(Canton canton);
        void Eliminar(int idCanton);
        IEnumerable<Canton> Listar();
    }
}
