using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class PedidoBL : IPedidoBL
    {
        private readonly PedidoDA _da = new();

        public void Insertar(Pedido p) => _da.Insertar(p);
        public void Modificar(Pedido p) => _da.Modificar(p);
        public void Eliminar(int idPedido) => _da.Eliminar(idPedido);
        public IEnumerable<Pedido> Listar() => _da.Listar();
    }
}
