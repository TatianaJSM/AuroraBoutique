using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class CategoriaBL : ICategoriaBL
    {
        private readonly CategoriaDA _da = new();

        public void Insertar(Categoria categoria) => _da.Insertar(categoria);
        public void Modificar(Categoria categoria) => _da.Modificar(categoria);
        public void Eliminar(int idCategoria) => _da.Eliminar(idCategoria);
        public IEnumerable<Categoria> Listar() => _da.Listar();
    }
}
