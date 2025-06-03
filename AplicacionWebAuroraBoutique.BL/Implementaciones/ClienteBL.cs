using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.DA.DataAccess;
using AplicacionWebAuroraBoutique.Modelo;
using System.Collections.Generic;

namespace AplicacionWebAuroraBoutique.BL.Implementaciones
{
    public class ClienteBL : IClienteBL
    {
        private readonly ClienteDA _da = new();

        public void Insertar(Cliente c) => _da.Insertar(c);
        public void Modificar(Cliente c) => _da.Modificar(c);
        public void Eliminar(int idCliente) => _da.Eliminar(idCliente);
        public IEnumerable<Cliente> Listar() => _da.Listar();
    }
}
