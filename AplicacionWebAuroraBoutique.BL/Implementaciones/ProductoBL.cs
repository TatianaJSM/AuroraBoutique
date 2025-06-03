using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class ProductoBL : IProductoBL
    {
        private readonly ProductoDA _da = new();

        public void Insertar(Producto p) => _da.Insertar(p);
        public void Modificar(Producto p) => _da.Modificar(p);
        public void Eliminar(int idProducto) => _da.Eliminar(idProducto);
        public IEnumerable<Producto> Listar() => _da.Listar();
    }
}
