using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class BarrioController : Controller
    {
        private readonly IBarrioBL _barrioBL;

        public BarrioController(IBarrioBL barrioBL)
        {
            _barrioBL = barrioBL;
        }

        public IActionResult Index()
        {
            var lista = _barrioBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                _barrioBL.Insertar(barrio);
                return RedirectToAction(nameof(Index));
            }
            return View(barrio);
        }

        public IActionResult Edit(int id)
        {
            var barrio = _barrioBL.Listar().FirstOrDefault(b => b.IdBarrio == id);
            if (barrio == null)
                return NotFound();

            return View(barrio);
        }

        [HttpPost]
        public IActionResult Edit(Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                _barrioBL.Modificar(barrio);
                return RedirectToAction(nameof(Index));
            }
            return View(barrio);
        }

        public IActionResult Delete(int id)
        {
            var barrio = _barrioBL.Listar().FirstOrDefault(b => b.IdBarrio == id);
            if (barrio == null)
                return NotFound();

            return View(barrio);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _barrioBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
