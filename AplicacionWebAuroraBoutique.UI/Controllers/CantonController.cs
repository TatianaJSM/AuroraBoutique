using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class CantonController : Controller
    {
        private readonly ICantonBL _cantonBL;

        public CantonController(ICantonBL cantonBL)
        {
            _cantonBL = cantonBL;
        }

        public IActionResult Index()
        {
            var lista = _cantonBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Canton canton)
        {
            if (ModelState.IsValid)
            {
                _cantonBL.Insertar(canton);
                return RedirectToAction(nameof(Index));
            }
            return View(canton);
        }

        public IActionResult Edit(int id)
        {
            var canton = _cantonBL.Listar().FirstOrDefault(c => c.IdCanton == id);
            if (canton == null)
                return NotFound();

            return View(canton);
        }

        [HttpPost]
        public IActionResult Edit(Canton canton)
        {
            if (ModelState.IsValid)
            {
                _cantonBL.Modificar(canton);
                return RedirectToAction(nameof(Index));
            }
            return View(canton);
        }

        public IActionResult Delete(int id)
        {
            var canton = _cantonBL.Listar().FirstOrDefault(c => c.IdCanton == id);
            if (canton == null)
                return NotFound();

            return View(canton);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _cantonBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
