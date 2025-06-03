using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class BitacoraClienteBL : IBitacoraClienteBL
    {
        private readonly BitacoraClienteDA _da = new();

        public void Insertar(BitacoraCliente bitacora) => _da.Insertar(bitacora);

        public void Modificar(BitacoraCliente bitacora) => _da.Modificar(bitacora);

        public void Eliminar(int idLog) => _da.Eliminar(idLog);

        public IEnumerable<BitacoraCliente> Listar() => _da.Listar();
    }
}
