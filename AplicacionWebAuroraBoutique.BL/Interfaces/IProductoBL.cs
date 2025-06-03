using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IProductoBL
    {
        void Insertar(Producto p);
        void Modificar(Producto p);
        void Eliminar(int idProducto);
        IEnumerable<Producto> Listar();
    }
}
