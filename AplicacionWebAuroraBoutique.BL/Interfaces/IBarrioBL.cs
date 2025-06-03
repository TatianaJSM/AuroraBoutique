using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IBarrioBL
    {
        void Insertar(Barrio barrio);
        void Modificar(Barrio barrio);
        void Eliminar(int idBarrio);
        IEnumerable<Barrio> Listar();
    }
}
