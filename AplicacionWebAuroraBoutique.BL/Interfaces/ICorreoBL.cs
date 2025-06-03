using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Interfaces
{
    public interface ICorreoBL
    {
        void Insertar(Correo correo);
        void Modificar(Correo correo);
        void Eliminar(int idCorreo);
        IEnumerable<Correo> Listar();
    }
}
