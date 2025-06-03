using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class AdministradorBL : IAdministradorBL
    {
        private readonly AdministradorDA _da = new();

        public void Insertar(Administrador admin) => _da.Insertar(admin);
        public void Modificar(Administrador admin) => _da.Modificar(admin);
        public void Eliminar(int idAdministrador) => _da.Eliminar(idAdministrador);
        public IEnumerable<Administrador> Listar() => _da.Listar();
    }
}
