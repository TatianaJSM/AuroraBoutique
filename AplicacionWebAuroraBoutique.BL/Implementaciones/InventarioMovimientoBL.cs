using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class InventarioMovimientoBL : IInventarioMovimientoBL
    {
        private readonly InventarioMovimientoDA _da = new();

        public void Insertar(InventarioMovimiento m) => _da.Insertar(m);
        public void Modificar(InventarioMovimiento m) => _da.Modificar(m);
        public void Eliminar(int idMovimiento) => _da.Eliminar(idMovimiento);
        public IEnumerable<InventarioMovimiento> Listar() => _da.Listar();
    }
}
