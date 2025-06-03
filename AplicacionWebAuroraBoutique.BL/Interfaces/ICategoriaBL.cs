using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ICategoriaBL
    {
        void Insertar(Categoria categoria);
        void Modificar(Categoria categoria);
        void Eliminar(int idCategoria);
        IEnumerable<Categoria> Listar();
    }
}
