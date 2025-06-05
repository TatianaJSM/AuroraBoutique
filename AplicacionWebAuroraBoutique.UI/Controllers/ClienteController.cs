using Microsoft.AspNetCore.Mvc;
using AplicacionWebAuroraBoutique.Modelo;
using AplicacionWebAuroraBoutique.BL.Interfaces;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteBL _clienteBL;

        public ClienteController(IClienteBL clienteBL)
        {
            _clienteBL = clienteBL;
        }

        // GET: Cliente
        public IActionResult Index()
        {
            var lista = _clienteBL.Listar();
            return View(lista);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteBL.Insertar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public IActionResult Edit(int id)
        {
            var cliente = _clienteBL.Listar().FirstOrDefault(c => c.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteBL.Modificar(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public IActionResult Delete(int id)
        {
            var cliente = _clienteBL.Listar().FirstOrDefault(c => c.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _clienteBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
