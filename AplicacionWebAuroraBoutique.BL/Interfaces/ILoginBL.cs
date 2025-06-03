using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ILoginBL
    {
        bool AutenticarCliente(string usuario, string contrasena);
        bool AutenticarAdministrador(string usuario, string contrasena);
        bool AutenticarPersonalEnvio(string usuario, string contrasena);
    }
}
