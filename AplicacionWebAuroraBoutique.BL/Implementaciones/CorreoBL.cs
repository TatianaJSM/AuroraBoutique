using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class CorreoBL : ICorreoBL
    {
        private readonly CorreoDA _da = new();

        public void Insertar(Correo correo) => _da.Insertar(correo);
        public void Modificar(Correo correo) => _da.Modificar(correo);
        public void Eliminar(int idCorreo) => _da.Eliminar(idCorreo);
        public IEnumerable<Correo> Listar() => _da.Listar();
    }
}
