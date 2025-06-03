using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class TelefonoBL : ITelefonoBL
    {
        private readonly TelefonoDA _da = new();

        public void Insertar(Telefono telefono) => _da.Insertar(telefono);
        public void Modificar(Telefono telefono) => _da.Modificar(telefono);
        public void Eliminar(int idTelefono) => _da.Eliminar(idTelefono);
        public IEnumerable<Telefono> Listar() => _da.Listar();
    }
}
