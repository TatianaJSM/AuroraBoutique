using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IResenaBL
    {
        void Insertar(Resena r);
        void Modificar(Resena r);
        void Eliminar(int idResena);
        IEnumerable<Resena> ListarPorProducto(int idProducto);
    }
}
