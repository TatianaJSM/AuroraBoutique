using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class PedidoPersonalEnvioBL : IPedidoPersonalEnvioBL
    {
        private readonly PedidoPersonalEnvioDA _da = new();

        public void Insertar(PedidoPersonalEnvio p) => _da.Insertar(p);
        public void Modificar(PedidoPersonalEnvio p) => _da.Modificar(p);
        public void Eliminar(int idPedidoEnvio) => _da.Eliminar(idPedidoEnvio);
        public IEnumerable<PedidoPersonalEnvio> Listar() => _da.Listar();
    }
}
