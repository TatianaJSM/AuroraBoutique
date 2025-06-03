using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IPaisBL
    {
        void Insertar(Pais pais);
        void Modificar(Pais pais);
        void Eliminar(int idPais);
        IEnumerable<Pais> Listar();
    }
}
