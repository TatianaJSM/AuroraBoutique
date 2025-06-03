using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class ProductoColorBL : IProductoColorBL
    {
        private readonly ProductoColorDA _da = new();

        public void Insertar(ProductoColor pc) => _da.Insertar(pc);
        public void Modificar(ProductoColor pc) => _da.Modificar(pc);
        public void Eliminar(int idProducto, int idColor) => _da.Eliminar(idProducto, idColor);
        public IEnumerable<ProductoColor> Listar() => _da.Listar();
    }
}
