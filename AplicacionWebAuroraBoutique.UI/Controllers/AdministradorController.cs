using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;
using AplicacionWebAuroraBoutique.BL.Implementaciones;


namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly IAdministradorBL _administradorBL;

        public AdministradorController(IAdministradorBL administradorBL)
        {
            _administradorBL = administradorBL;
        }

        // GET: Administrador
        public IActionResult Index()
        {
            var lista = _administradorBL.Listar();
            return View(lista);
        }

        // GET: Administrador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _administradorBL.Insertar(administrador);
                return RedirectToAction(nameof(Index));
            }
            return View(administrador);
        }

        // GET: Administrador/Edit/5
        public IActionResult Edit(int id)
        {
            var administrador = _administradorBL.Listar().FirstOrDefault(a => a.IdAdministrador == id);
            if (administrador == null)
            {
                return NotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _administradorBL.Modificar(administrador);
                return RedirectToAction(nameof(Index));
            }
            return View(administrador);
        }

        // GET: Administrador/Delete/5
        public IActionResult Delete(int id)
        {
            var administrador = _administradorBL.Listar().FirstOrDefault(a => a.IdAdministrador == id);
            if (administrador == null)
            {
                return NotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _administradorBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
