using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class TipoFechaBL : ITipoFechaBL
    {
        private readonly TipoFechaDA _da = new();

        public void Insertar(TipoFecha tipoFecha) => _da.Insertar(tipoFecha);
        public void Modificar(TipoFecha tipoFecha) => _da.Modificar(tipoFecha);
        public void Eliminar(int idTipoFecha) => _da.Eliminar(idTipoFecha);
        public IEnumerable<TipoFecha> Listar() => _da.Listar();
    }
}
