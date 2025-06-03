using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IProductoTallaBL
    {
        void Insertar(ProductoTalla pt);
        void Modificar(ProductoTalla pt);
        void Eliminar(int idProducto, int idTalla);
        IEnumerable<ProductoTalla> Listar();
    }
}
