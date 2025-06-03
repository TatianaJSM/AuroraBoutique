using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IPersonalEnvioBL
    {
        void Insertar(PersonalEnvio p);
        void Modificar(PersonalEnvio p);
        void Eliminar(int idPersonalEnvio);
        IEnumerable<PersonalEnvio> Listar();
    }
}
