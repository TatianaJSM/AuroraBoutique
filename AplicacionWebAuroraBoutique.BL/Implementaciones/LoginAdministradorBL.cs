using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class LoginAdministradorBL : ILoginAdministradorBL
    {
        private readonly LoginAdministradorDA _da = new();

        public void Insertar(LoginAdministrador login) => _da.Insertar(login);
        public void Modificar(LoginAdministrador login) => _da.Modificar(login);
        public void Eliminar(int idLogin) => _da.Eliminar(idLogin);
        public IEnumerable<LoginAdministrador> Listar() => _da.Listar();
        public int? Autenticar(string usuario, string contrasena) => _da.Autenticar(usuario, contrasena);
    }
}
