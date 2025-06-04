using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class TipoFechaController : Controller
    {
        private readonly ITipoFechaBL _tipoFechaBL;

        public TipoFechaController(ITipoFechaBL tipoFechaBL)
        {
            _tipoFechaBL = tipoFechaBL;
        }

        public IActionResult Index()
        {
            var lista = _tipoFechaBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TipoFecha tipoFecha)
        {
            if (ModelState.IsValid)
            {
                _tipoFechaBL.Insertar(tipoFecha);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFecha);
        }

        public IActionResult Edit(int id)
        {
            var tipoFecha = _tipoFechaBL.Listar().FirstOrDefault(t => t.IdTipoFecha == id);
            if (tipoFecha == null)
                return NotFound();

            return View(tipoFecha);
        }

        [HttpPost]
        public IActionResult Edit(TipoFecha tipoFecha)
        {
            if (ModelState.IsValid)
            {
                _tipoFechaBL.Modificar(tipoFecha);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoFecha);
        }

        public IActionResult Delete(int id)
        {
            var tipoFecha = _tipoFechaBL.Listar().FirstOrDefault(t => t.IdTipoFecha == id);
            if (tipoFecha == null)
                return NotFound();

            return View(tipoFecha);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _tipoFechaBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
