using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class CantonBL : ICantonBL
    {
        private readonly CantonDA _da = new();

        public void Insertar(Canton canton) => _da.Insertar(canton);
        public void Modificar(Canton canton) => _da.Modificar(canton);
        public void Eliminar(int idCanton) => _da.Eliminar(idCanton);
        public IEnumerable<Canton> Listar() => _da.Listar();
    }
}
