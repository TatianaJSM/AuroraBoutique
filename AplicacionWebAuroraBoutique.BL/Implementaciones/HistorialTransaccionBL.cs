using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class HistorialTransaccionBL : IHistorialTransaccionBL
    {
        private readonly HistorialTransaccionDA _da = new();

        public void Insertar(HistorialTransaccion h) => _da.Insertar(h);
        public void Modificar(HistorialTransaccion h) => _da.Modificar(h);
        public void Eliminar(int idTransaccion) => _da.Eliminar(idTransaccion);
        public IEnumerable<HistorialTransaccion> Listar() => _da.Listar();
    }
}
