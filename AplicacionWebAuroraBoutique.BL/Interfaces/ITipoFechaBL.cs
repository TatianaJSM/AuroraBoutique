using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ITipoFechaBL
    {
        void Insertar(TipoFecha tipoFecha);
        void Modificar(TipoFecha tipoFecha);
        void Eliminar(int idTipoFecha);
        IEnumerable<TipoFecha> Listar();
    }
}
