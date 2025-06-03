using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class PersonalEnvioBL : IPersonalEnvioBL
    {
        private readonly PersonalEnvioDA _da = new();

        public void Insertar(PersonalEnvio p) => _da.Insertar(p);
        public void Modificar(PersonalEnvio p) => _da.Modificar(p);
        public void Eliminar(int idPersonalEnvio) => _da.Eliminar(idPersonalEnvio);
        public IEnumerable<PersonalEnvio> Listar() => _da.Listar();
    }
}
