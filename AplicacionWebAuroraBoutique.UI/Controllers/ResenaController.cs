using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class ResenaController : Controller
    {
        private readonly IResenaBL _resenaBL;

        public ResenaController(IResenaBL resenaBL)
        {
            _resenaBL = resenaBL;
        }

        public IActionResult Index()
        {
            var lista = _resenaBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Resena resena)
        {
            if (ModelState.IsValid)
            {
                _resenaBL.Insertar(resena);
                return RedirectToAction(nameof(Index));
            }
            return View(resena);
        }

        public IActionResult Edit(int id)
        {
            var resena = _resenaBL.Listar().FirstOrDefault(r => r.IdResena == id);
            if (resena == null)
                return NotFound();

            return View(resena);
        }

        [HttpPost]
        public IActionResult Edit(Resena resena)
        {
            if (ModelState.IsValid)
            {
                _resenaBL.Modificar(resena);
                return RedirectToAction(nameof(Index));
            }
            return View(resena);
        }

        public IActionResult Delete(int id)
        {
            var resena = _resenaBL.Listar().FirstOrDefault(r => r.IdResena == id);
            if (resena == null)
                return NotFound();

            return View(resena);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _resenaBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
