using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IPedidoBL
    {
        void Insertar(Pedido p);
        void Modificar(Pedido p);
        void Eliminar(int idPedido);
        IEnumerable<Pedido> Listar();
    }
}
