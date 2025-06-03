using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ILoginAdministradorBL
    {
        void Insertar(LoginAdministrador login);
        void Modificar(LoginAdministrador login);
        void Eliminar(int idLogin);
        IEnumerable<LoginAdministrador> Listar();
        int? Autenticar(string usuario, string contrasena);
    }
}
