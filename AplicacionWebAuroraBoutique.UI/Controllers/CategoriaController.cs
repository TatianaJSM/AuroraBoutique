using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaBL _categoriaBL;

        public CategoriaController(ICategoriaBL categoriaBL)
        {
            _categoriaBL = categoriaBL;
        }

        public IActionResult Index()
        {
            var lista = _categoriaBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaBL.Insertar(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public IActionResult Edit(int id)
        {
            var categoria = _categoriaBL.Listar().FirstOrDefault(c => c.IdCategoria == id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _categoriaBL.Modificar(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }

        public IActionResult Delete(int id)
        {
            var categoria = _categoriaBL.Listar().FirstOrDefault(c => c.IdCategoria == id);
            if (categoria == null)
                return NotFound();

            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _categoriaBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
