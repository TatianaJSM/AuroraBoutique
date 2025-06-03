using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class DetallePedidoBL : IDetallePedidoBL
    {
        private readonly DetallePedidoDA _da = new();

        public void Insertar(DetallePedido detalle) => _da.Insertar(detalle);
        public void Modificar(DetallePedido detalle) => _da.Modificar(detalle);
        public void Eliminar(int idDetalle) => _da.Eliminar(idDetalle);
        public IEnumerable<DetallePedido> Listar() => _da.Listar();
    }
}
