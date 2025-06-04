using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class InventarioMovimientoController : Controller
    {
        private readonly IInventarioMovimientoBL _inventarioMovimientoBL;

        public InventarioMovimientoController(IInventarioMovimientoBL inventarioMovimientoBL)
        {
            _inventarioMovimientoBL = inventarioMovimientoBL;
        }

        public IActionResult Index()
        {
            var lista = _inventarioMovimientoBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InventarioMovimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                _inventarioMovimientoBL.Insertar(movimiento);
                return RedirectToAction(nameof(Index));
            }
            return View(movimiento);
        }

        public IActionResult Edit(int id)
        {
            var movimiento = _inventarioMovimientoBL.Listar().FirstOrDefault(m => m.IdMovimiento == id);
            if (movimiento == null)
                return NotFound();

            return View(movimiento);
        }

        [HttpPost]
        public IActionResult Edit(InventarioMovimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                _inventarioMovimientoBL.Modificar(movimiento);
                return RedirectToAction(nameof(Index));
            }
            return View(movimiento);
        }

        public IActionResult Delete(int id)
        {
            var movimiento = _inventarioMovimientoBL.Listar().FirstOrDefault(m => m.IdMovimiento == id);
            if (movimiento == null)
                return NotFound();

            return View(movimiento);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _inventarioMovimientoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
