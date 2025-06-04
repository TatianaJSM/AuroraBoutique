using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorBL _colorBL;

        public ColorController(IColorBL colorBL)
        {
            _colorBL = colorBL;
        }

        public IActionResult Index()
        {
            var lista = _colorBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Color color)
        {
            if (ModelState.IsValid)
            {
                _colorBL.Insertar(color);
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        public IActionResult Edit(int id)
        {
            var color = _colorBL.Listar().FirstOrDefault(c => c.IdColor == id);
            if (color == null)
                return NotFound();

            return View(color);
        }

        [HttpPost]
        public IActionResult Edit(Color color)
        {
            if (ModelState.IsValid)
            {
                _colorBL.Modificar(color);
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        public IActionResult Delete(int id)
        {
            var color = _colorBL.Listar().FirstOrDefault(c => c.IdColor == id);
            if (color == null)
                return NotFound();

            return View(color);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _colorBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
