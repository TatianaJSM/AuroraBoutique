using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class MetodoPagoController : Controller
    {
        private readonly IMetodoPagoBL _metodoPagoBL;

        public MetodoPagoController(IMetodoPagoBL metodoPagoBL)
        {
            _metodoPagoBL = metodoPagoBL;
        }

        public IActionResult Index()
        {
            var lista = _metodoPagoBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MetodoPago metodoPago)
        {
            if (ModelState.IsValid)
            {
                _metodoPagoBL.Insertar(metodoPago);
                return RedirectToAction(nameof(Index));
            }
            return View(metodoPago);
        }

        public IActionResult Edit(int id)
        {
            var metodoPago = _metodoPagoBL.Listar().FirstOrDefault(m => m.IdMetodoPago == id);
            if (metodoPago == null)
                return NotFound();

            return View(metodoPago);
        }

        [HttpPost]
        public IActionResult Edit(MetodoPago metodoPago)
        {
            if (ModelState.IsValid)
            {
                _metodoPagoBL.Modificar(metodoPago);
                return RedirectToAction(nameof(Index));
            }
            return View(metodoPago);
        }

        public IActionResult Delete(int id)
        {
            var metodoPago = _metodoPagoBL.Listar().FirstOrDefault(m => m.IdMetodoPago == id);
            if (metodoPago == null)
                return NotFound();

            return View(metodoPago);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _metodoPagoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
