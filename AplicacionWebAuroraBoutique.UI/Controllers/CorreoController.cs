using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class CorreoController : Controller
    {
        private readonly ICorreoBL _correoBL;

        public CorreoController(ICorreoBL correoBL)
        {
            _correoBL = correoBL;
        }

        public IActionResult Index()
        {
            var lista = _correoBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Correo correo)
        {
            if (ModelState.IsValid)
            {
                _correoBL.Insertar(correo);
                return RedirectToAction(nameof(Index));
            }
            return View(correo);
        }

        public IActionResult Edit(int id)
        {
            var correo = _correoBL.Listar().FirstOrDefault(c => c.IdCorreo == id);
            if (correo == null)
                return NotFound();

            return View(correo);
        }

        [HttpPost]
        public IActionResult Edit(Correo correo)
        {
            if (ModelState.IsValid)
            {
                _correoBL.Modificar(correo);
                return RedirectToAction(nameof(Index));
            }
            return View(correo);
        }

        public IActionResult Delete(int id)
        {
            var correo = _correoBL.Listar().FirstOrDefault(c => c.IdCorreo == id);
            if (correo == null)
                return NotFound();

            return View(correo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _correoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
