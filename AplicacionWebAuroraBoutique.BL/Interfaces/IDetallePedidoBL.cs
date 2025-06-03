using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IDetallePedidoBL
    {
        void Insertar(DetallePedido detalle);
        void Modificar(DetallePedido detalle);
        void Eliminar(int idDetalle);
        IEnumerable<DetallePedido> Listar();
    }
}
