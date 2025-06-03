using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ILoginClienteBL
    {
        void Insertar(LoginCliente login);
        void Modificar(LoginCliente login);
        void Eliminar(int idLogin);
        IEnumerable<LoginCliente> Listar();
        int? Autenticar(string usuario, string contrasena);
    }
}
