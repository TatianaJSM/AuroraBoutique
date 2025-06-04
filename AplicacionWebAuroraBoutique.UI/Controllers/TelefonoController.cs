using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class TelefonoController : Controller
    {
        private readonly ITelefonoBL _telefonoBL;

        public TelefonoController(ITelefonoBL telefonoBL)
        {
            _telefonoBL = telefonoBL;
        }

        public IActionResult Index()
        {
            var lista = _telefonoBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _telefonoBL.Insertar(telefono);
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        public IActionResult Edit(int id)
        {
            var telefono = _telefonoBL.Listar().FirstOrDefault(t => t.IdTelefono == id);
            if (telefono == null)
                return NotFound();

            return View(telefono);
        }

        [HttpPost]
        public IActionResult Edit(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _telefonoBL.Modificar(telefono);
                return RedirectToAction(nameof(Index));
            }
            return View(telefono);
        }

        public IActionResult Delete(int id)
        {
            var telefono = _telefonoBL.Listar().FirstOrDefault(t => t.IdTelefono == id);
            if (telefono == null)
                return NotFound();

            return View(telefono);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _telefonoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
