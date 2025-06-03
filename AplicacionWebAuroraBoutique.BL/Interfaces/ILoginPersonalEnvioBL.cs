using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ILoginPersonalEnvioBL
    {
        void Insertar(LoginPersonalEnvio login);
        void Modificar(LoginPersonalEnvio login);
        void Eliminar(int idLogin);
        IEnumerable<LoginPersonalEnvio> Listar();
        int? Autenticar(string usuario, string contrasena);
    }
}
