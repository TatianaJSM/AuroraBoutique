using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IProductoColorBL
    {
        void Insertar(ProductoColor pc);
        void Modificar(ProductoColor pc);
        void Eliminar(int idProducto, int idColor);
        IEnumerable<ProductoColor> Listar();
    }
}
