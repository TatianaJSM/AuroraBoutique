using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class ColorBL : IColorBL
    {
        private readonly ColorDA _da = new();

        public void Insertar(Color color) => _da.Insertar(color);
        public void Modificar(Color color) => _da.Modificar(color);
        public void Eliminar(int idColor) => _da.Eliminar(idColor);
        public IEnumerable<Color> Listar() => _da.Listar();
    }
}
