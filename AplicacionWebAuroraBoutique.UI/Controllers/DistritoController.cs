using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class DistritoController : Controller
    {
        private readonly IDistritoBL _distritoBL;

        public DistritoController(IDistritoBL distritoBL)
        {
            _distritoBL = distritoBL;
        }

        public IActionResult Index()
        {
            var lista = _distritoBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _distritoBL.Insertar(distrito);
                return RedirectToAction(nameof(Index));
            }
            return View(distrito);
        }

        public IActionResult Edit(int id)
        {
            var distrito = _distritoBL.Listar().FirstOrDefault(d => d.IdDistrito == id);
            if (distrito == null)
                return NotFound();

            return View(distrito);
        }

        [HttpPost]
        public IActionResult Edit(Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                _distritoBL.Modificar(distrito);
                return RedirectToAction(nameof(Index));
            }
            return View(distrito);
        }

        public IActionResult Delete(int id)
        {
            var distrito = _distritoBL.Listar().FirstOrDefault(d => d.IdDistrito == id);
            if (distrito == null)
                return NotFound();

            return View(distrito);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _distritoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
