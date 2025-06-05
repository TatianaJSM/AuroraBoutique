using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class ResenaBL : IResenaBL
    {
        private readonly ResenaDA _resenaDA = new();

        public void Insertar(Resena r)
        {
            _resenaDA.Insertar(r);
        }

        public void Modificar(Resena r)
        {
            _resenaDA.Modificar(r);
        }

        public void Eliminar(int idResena)
        {
            _resenaDA.Eliminar(idResena);
        }

        public IEnumerable<Resena> Listar()
        {
            return _resenaDA.Listar();
        }

        public IEnumerable<Resena> ListarPorProducto(int idProducto)
        {
            return _resenaDA.ListarPorProducto(idProducto);
        }
    }
}
