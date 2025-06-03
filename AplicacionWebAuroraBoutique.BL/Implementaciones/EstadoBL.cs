using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class EstadoBL : IEstadoBL
    {
        private readonly EstadoDA _da = new();

        public void Insertar(Estado estado) => _da.Insertar(estado);
        public void Modificar(Estado estado) => _da.Modificar(estado);
        public void Eliminar(int idEstado) => _da.Eliminar(idEstado);
        public IEnumerable<Estado> Listar() => _da.Listar();
    }
}
