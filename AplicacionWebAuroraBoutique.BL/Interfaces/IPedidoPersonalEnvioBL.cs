using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IPedidoPersonalEnvioBL
    {
        void Insertar(PedidoPersonalEnvio p);
        void Modificar(PedidoPersonalEnvio p);
        void Eliminar(int idPedidoEnvio);
        IEnumerable<PedidoPersonalEnvio> Listar();
    }
}
