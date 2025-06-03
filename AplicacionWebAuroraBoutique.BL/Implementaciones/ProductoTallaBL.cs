using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class ProductoTallaBL : IProductoTallaBL
    {
        private readonly ProductoTallaDA _da = new();

        public void Insertar(ProductoTalla pt) => _da.Insertar(pt);
        public void Modificar(ProductoTalla pt) => _da.Modificar(pt);
        public void Eliminar(int idProducto, int idTalla) => _da.Eliminar(idProducto, idTalla);
        public IEnumerable<ProductoTalla> Listar() => _da.Listar();
    }
}
