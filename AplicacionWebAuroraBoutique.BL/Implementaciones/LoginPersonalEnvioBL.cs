using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class LoginPersonalEnvioBL : ILoginPersonalEnvioBL
    {
        private readonly LoginPersonalEnvioDA _da = new();

        public void Insertar(LoginPersonalEnvio login) => _da.Insertar(login);
        public void Modificar(LoginPersonalEnvio login) => _da.Modificar(login);
        public void Eliminar(int idLogin) => _da.Eliminar(idLogin);
        public IEnumerable<LoginPersonalEnvio> Listar() => _da.Listar();
        public int? Autenticar(string usuario, string contrasena) => _da.Autenticar(usuario, contrasena);
    }
}
