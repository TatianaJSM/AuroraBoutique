using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IDistritoBL
    {
        void Insertar(Distrito d);
        void Modificar(Distrito d);
        void Eliminar(int idDistrito);
        IEnumerable<Distrito> Listar();
    }
}
