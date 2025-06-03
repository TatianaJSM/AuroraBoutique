using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IMetodoPagoBL
    {
        void Insertar(MetodoPago metodo);
        void Modificar(MetodoPago metodo);
        void Eliminar(int idMetodoPago);
        IEnumerable<MetodoPago> Listar();
    }
}
