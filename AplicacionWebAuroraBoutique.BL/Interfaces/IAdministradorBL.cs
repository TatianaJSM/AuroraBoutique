using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IAdministradorBL
    {
        void Insertar(Administrador admin);
        void Modificar(Administrador admin);
        void Eliminar(int idAdministrador);
        IEnumerable<Administrador> Listar();
    }
}
