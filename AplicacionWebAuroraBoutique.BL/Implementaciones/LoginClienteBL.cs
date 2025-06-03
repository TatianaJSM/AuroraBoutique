using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class LoginClienteBL : ILoginClienteBL
    {
        private readonly LoginClienteDA _da = new();

        public void Insertar(LoginCliente login) => _da.Insertar(login);
        public void Modificar(LoginCliente login) => _da.Modificar(login);
        public void Eliminar(int idLogin) => _da.Eliminar(idLogin);
        public IEnumerable<LoginCliente> Listar() => _da.Listar();
        public int? Autenticar(string usuario, string contrasena) => _da.Autenticar(usuario, contrasena);
    }
}
