using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ITallaBL
    {
        void Insertar(Talla t);
        void Modificar(Talla t);
        void Eliminar(int idTalla);
        IEnumerable<Talla> Listar();
    }
}
