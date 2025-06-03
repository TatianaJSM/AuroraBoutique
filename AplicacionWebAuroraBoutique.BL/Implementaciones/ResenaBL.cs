using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class ResenaBL : IResenaBL
    {
        private readonly ResenaDA _da = new();

        public void Insertar(Resena r) => _da.Insertar(r);
        public void Modificar(Resena r) => _da.Modificar(r);
        public void Eliminar(int idResena) => _da.Eliminar(idResena);
        public IEnumerable<Resena> ListarPorProducto(int idProducto) => _da.ListarPorProducto(idProducto);
    }
}
