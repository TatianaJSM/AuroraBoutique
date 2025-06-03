using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class LogEventoBL : ILogEventoBL
    {
        private readonly LogEventoDA _da = new();

        public void Insertar(LogEvento log) => _da.Insertar(log);
        public void Modificar(LogEvento log) => _da.Modificar(log);
        public void Eliminar(int idLog) => _da.Eliminar(idLog);
        public IEnumerable<LogEvento> Listar() => _da.Listar();
    }
}
