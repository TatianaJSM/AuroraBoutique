using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class HistorialTransaccionController : Controller
    {
        private readonly IHistorialTransaccionBL _historialTransaccionBL;

        public HistorialTransaccionController(IHistorialTransaccionBL historialTransaccionBL)
        {
            _historialTransaccionBL = historialTransaccionBL;
        }

        public IActionResult Index()
        {
            var lista = _historialTransaccionBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HistorialTransaccion historial)
        {
            if (ModelState.IsValid)
            {
                _historialTransaccionBL.Insertar(historial);
                return RedirectToAction(nameof(Index));
            }
            return View(historial);
        }

        public IActionResult Edit(int id)
        {
            var historial = _historialTransaccionBL.Listar().FirstOrDefault(h => h.IdTransaccion == id);
            if (historial == null)
                return NotFound();

            return View(historial);
        }

        [HttpPost]
        public IActionResult Edit(HistorialTransaccion historial)
        {
            if (ModelState.IsValid)
            {
                _historialTransaccionBL.Modificar(historial);
                return RedirectToAction(nameof(Index));
            }
            return View(historial);
        }

        public IActionResult Delete(int id)
        {
            var historial = _historialTransaccionBL.Listar().FirstOrDefault(h => h.IdTransaccion == id);
            if (historial == null)
                return NotFound();

            return View(historial);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _historialTransaccionBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
