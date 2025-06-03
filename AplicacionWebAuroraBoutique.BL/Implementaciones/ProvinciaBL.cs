using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class ProvinciaBL : IProvinciaBL
    {
        private readonly ProvinciaDA _da = new();

        public void Insertar(Provincia p) => _da.Insertar(p);
        public void Modificar(Provincia p) => _da.Modificar(p);
        public void Eliminar(int idProvincia) => _da.Eliminar(idProvincia);
        public IEnumerable<Provincia> Listar() => _da.Listar();
    }
}
