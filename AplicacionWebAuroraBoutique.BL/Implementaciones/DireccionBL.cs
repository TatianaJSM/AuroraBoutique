using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class DireccionBL : IDireccionBL
    {
        private readonly DireccionDA _da = new();

        public void Insertar(Direccion d) => _da.Insertar(d);
        public void Modificar(Direccion d) => _da.Modificar(d);
        public void Eliminar(int idDireccion) => _da.Eliminar(idDireccion);
        public IEnumerable<Direccion> Listar() => _da.Listar();
    }
}
