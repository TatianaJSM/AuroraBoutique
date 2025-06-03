using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IProvinciaBL
    {
        void Insertar(Provincia p);
        void Modificar(Provincia p);
        void Eliminar(int idProvincia);
        IEnumerable<Provincia> Listar();
    }
}
