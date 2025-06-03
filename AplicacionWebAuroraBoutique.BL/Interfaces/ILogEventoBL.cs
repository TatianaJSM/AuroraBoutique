using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ILogEventoBL
    {
        void Insertar(LogEvento log);
        void Modificar(LogEvento log);
        void Eliminar(int idLog);
        IEnumerable<LogEvento> Listar();
    }
}
