using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IInventarioMovimientoBL
    {
        void Insertar(InventarioMovimiento m);
        void Modificar(InventarioMovimiento m);
        void Eliminar(int idMovimiento);
        IEnumerable<InventarioMovimiento> Listar();
    }
}
