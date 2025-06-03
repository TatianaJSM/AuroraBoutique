using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class PaisBL : IPaisBL
    {
        private readonly PaisDA _da = new();

        public void Insertar(Pais pais) => _da.Insertar(pais);
        public void Modificar(Pais pais) => _da.Modificar(pais);
        public void Eliminar(int idPais) => _da.Eliminar(idPais);
        public IEnumerable<Pais> Listar() => _da.Listar();
    }
}
