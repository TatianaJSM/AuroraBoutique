using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class TallaController : Controller
    {
        private readonly ITallaBL _tallaBL;

        public TallaController(ITallaBL tallaBL)
        {
            _tallaBL = tallaBL;
        }

        public IActionResult Index()
        {
            var lista = _tallaBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Talla talla)
        {
            if (ModelState.IsValid)
            {
                _tallaBL.Insertar(talla);
                return RedirectToAction(nameof(Index));
            }
            return View(talla);
        }

        public IActionResult Edit(int id)
        {
            var talla = _tallaBL.Listar().FirstOrDefault(t => t.IdTalla == id);
            if (talla == null)
                return NotFound();

            return View(talla);
        }

        [HttpPost]
        public IActionResult Edit(Talla talla)
        {
            if (ModelState.IsValid)
            {
                _tallaBL.Modificar(talla);
                return RedirectToAction(nameof(Index));
            }
            return View(talla);
        }

        public IActionResult Delete(int id)
        {
            var talla = _tallaBL.Listar().FirstOrDefault(t => t.IdTalla == id);
            if (talla == null)
                return NotFound();

            return View(talla);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _tallaBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
