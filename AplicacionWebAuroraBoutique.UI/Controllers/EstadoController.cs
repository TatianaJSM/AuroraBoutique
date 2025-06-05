using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class EstadoController : Controller
    {
        private readonly IEstadoBL _estadoBL;

        public EstadoController(IEstadoBL estadoBL)
        {
            _estadoBL = estadoBL;
        }

        public IActionResult Index()
        {
            var lista = _estadoBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Estado estado)
        {
            if (ModelState.IsValid)
            {
                _estadoBL.Insertar(estado);
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        public IActionResult Edit(int id)
        {
            var estado = _estadoBL.Listar().FirstOrDefault(e => e.IdEstado == id);
            if (estado == null)
                return NotFound();

            return View(estado);
        }

        [HttpPost]
        public IActionResult Edit(Estado estado)
        {
            if (ModelState.IsValid)
            {
                _estadoBL.Modificar(estado);
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        public IActionResult Delete(int id)
        {
            var estado = _estadoBL.Listar().FirstOrDefault(e => e.IdEstado == id);
            if (estado == null)
                return NotFound();

            return View(estado);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _estadoBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
