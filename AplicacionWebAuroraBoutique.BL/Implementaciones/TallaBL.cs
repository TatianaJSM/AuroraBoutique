using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class TallaBL : ITallaBL
    {
        private readonly TallaDA _da = new();

        public void Insertar(Talla t) => _da.Insertar(t);
        public void Modificar(Talla t) => _da.Modificar(t);
        public void Eliminar(int idTalla) => _da.Eliminar(idTalla);
        public IEnumerable<Talla> Listar() => _da.Listar();
    }
}
