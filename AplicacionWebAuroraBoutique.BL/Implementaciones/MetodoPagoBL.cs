using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class MetodoPagoBL : IMetodoPagoBL
    {
        private readonly MetodoPagoDA _da = new();

        public void Insertar(MetodoPago metodo) => _da.Insertar(metodo);
        public void Modificar(MetodoPago metodo) => _da.Modificar(metodo);
        public void Eliminar(int idMetodoPago) => _da.Eliminar(idMetodoPago);
        public IEnumerable<MetodoPago> Listar() => _da.Listar();
    }
}
