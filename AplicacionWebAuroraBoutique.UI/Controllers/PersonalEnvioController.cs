using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class PersonalEnvioController : Controller
    {
        private readonly IPersonalEnvioBL _personalEnvioBL;

        public PersonalEnvioController(IPersonalEnvioBL personalEnvioBL)
        {
            _personalEnvioBL = personalEnvioBL;
        }

        // GET: PersonalEnvio
        public IActionResult Index()
        {
            var lista = _personalEnvioBL.Listar();
            return View(lista);
        }

        // GET: PersonalEnvio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalEnvio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonalEnvio personal)
        {
            if (ModelState.IsValid)
            {
                _personalEnvioBL.Insertar(personal);
                return RedirectToAction(nameof(Index));
            }
            return View(personal);
        }

        // GET: PersonalEnvio/Edit/5
        public IActionResult Edit(int id)
        {
            var personal = _personalEnvioBL.Listar().FirstOrDefault(p => p.IdPersonalEnvio == id);
            if (personal == null)
            {
                return NotFound();
            }
            return View(personal);
        }

        // POST: PersonalEnvio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PersonalEnvio personal)
        {
            if (ModelState.IsValid)
            {
                _personalEnvioBL.Modificar(personal);
                return RedirectToAction(nameof(Index));
            }
            return View(personal);
        }

        // GET: PersonalEnvio/Delete/5
        public IActionResult Delete(int id)
        {
            var personal = _personalEnvioBL.Listar().FirstOrDefault(p => p.IdPersonalEnvio == id);
            if (personal == null)
            {
                return NotFound();
            }
            return View(personal);
        }

        // POST: PersonalEnvio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _personalEnvioBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
