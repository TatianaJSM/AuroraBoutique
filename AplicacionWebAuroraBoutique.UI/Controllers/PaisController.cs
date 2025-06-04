using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class PaisController : Controller
    {
        private readonly IPaisBL _paisBL;

        public PaisController(IPaisBL paisBL)
        {
            _paisBL = paisBL;
        }

        public IActionResult Index()
        {
            var lista = _paisBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pais pais)
        {
            if (ModelState.IsValid)
            {
                _paisBL.Insertar(pais);
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        public IActionResult Edit(int id)
        {
            var pais = _paisBL.Listar().FirstOrDefault(p => p.IdPais == id);
            if (pais == null)
                return NotFound();

            return View(pais);
        }

        [HttpPost]
        public IActionResult Edit(Pais pais)
        {
            if (ModelState.IsValid)
            {
                _paisBL.Modificar(pais);
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        public IActionResult Delete(int id)
        {
            var pais = _paisBL.Listar().FirstOrDefault(p => p.IdPais == id);
            if (pais == null)
                return NotFound();

            return View(pais);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _paisBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
