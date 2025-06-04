using Microsoft.AspNetCore.Mvc;
using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;


namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class ProvinciaController : Controller
    {
        private readonly IProvinciaBL _provinciaBL;

        public ProvinciaController(IProvinciaBL provinciaBL)
        {
            _provinciaBL = provinciaBL;
        }

        public IActionResult Index()
        {
            var lista = _provinciaBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _provinciaBL.Insertar(provincia);
                return RedirectToAction(nameof(Index));
            }
            return View(provincia);
        }

        public IActionResult Edit(int id)
        {
            var provincia = _provinciaBL.Listar().FirstOrDefault(p => p.IdProvincia == id);
            if (provincia == null)
                return NotFound();

            return View(provincia);
        }

        [HttpPost]
        public IActionResult Edit(Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                _provinciaBL.Modificar(provincia);
                return RedirectToAction(nameof(Index));
            }
            return View(provincia);
        }

        public IActionResult Delete(int id)
        {
            var provincia = _provinciaBL.Listar().FirstOrDefault(p => p.IdProvincia == id);
            if (provincia == null)
                return NotFound();

            return View(provincia);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _provinciaBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
