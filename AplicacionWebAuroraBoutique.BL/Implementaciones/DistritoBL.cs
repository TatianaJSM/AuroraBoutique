using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class DistritoBL : IDistritoBL
    {
        private readonly DistritoDA _da = new();

        public void Insertar(Distrito d) => _da.Insertar(d);
        public void Modificar(Distrito d) => _da.Modificar(d);
        public void Eliminar(int idDistrito) => _da.Eliminar(idDistrito);
        public IEnumerable<Distrito> Listar() => _da.Listar();
    }
}
