using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface IColorBL
    {
        void Insertar(Color color);
        void Modificar(Color color);
        void Eliminar(int idColor);
        IEnumerable<Color> Listar();
    }
}
