using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class BarrioBL : IBarrioBL
    {
        private readonly BarrioDA _da = new();

        public void Insertar(Barrio barrio) => _da.Insertar(barrio);
        public void Modificar(Barrio barrio) => _da.Modificar(barrio);
        public void Eliminar(int idBarrio) => _da.Eliminar(idBarrio);
        public IEnumerable<Barrio> Listar() => _da.Listar();
    }
}
