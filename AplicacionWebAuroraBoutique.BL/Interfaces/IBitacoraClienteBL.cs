using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IBitacoraClienteBL
    {
        void Insertar(BitacoraCliente bitacora);
        void Modificar(BitacoraCliente bitacora);
        void Eliminar(int idLog);
        IEnumerable<BitacoraCliente> Listar();
    }
}
