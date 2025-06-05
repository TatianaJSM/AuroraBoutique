using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IPedidoBL _pedidoBL;

        public PedidoController(IPedidoBL pedidoBL)
        {
            _pedidoBL = pedidoBL;
        }

        // GET: Pedido
        public IActionResult Index()
        {
            var lista = _pedidoBL.Listar();
            return View(lista);
        }

        // GET: Pedido/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _pedidoBL.Insertar(pedido);
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedido/Edit/5
        public IActionResult Edit(int id)
        {
            var pedido = _pedidoBL.Listar().FirstOrDefault(p => p.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                _pedidoBL.Modificar(pedido);
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        // GET: Pedido/Delete/5
        public IActionResult Delete(int id)
        {
            var pedido = _pedidoBL.Listar().FirstOrDefault(p => p.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _pedidoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
