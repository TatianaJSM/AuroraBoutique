using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IHistorialTransaccionBL
    {
        void Insertar(HistorialTransaccion h);
        void Modificar(HistorialTransaccion h);
        void Eliminar(int idTransaccion);
        IEnumerable<HistorialTransaccion> Listar();
    }
}
