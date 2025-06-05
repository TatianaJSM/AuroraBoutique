using AplicacionWebAuroraBoutique.BL.Interfaces;
using AplicacionWebAuroraBoutique.Modelo;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionWebAuroraBoutique.UI.Controllers
{
    public class LoginClienteController : Controller
    {
        private readonly ILoginClienteBL _loginClienteBL;

        public LoginClienteController(ILoginClienteBL loginClienteBL)
        {
            _loginClienteBL = loginClienteBL;
        }

        public IActionResult Index()
        {
            var lista = _loginClienteBL.Listar();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoginCliente login)
        {
            if (ModelState.IsValid)
            {
                _loginClienteBL.Insertar(login);
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        public IActionResult Edit(int id)
        {
            var login = _loginClienteBL.Listar().FirstOrDefault(l => l.IdLoginCliente == id);
            if (login == null)
                return NotFound();

            return View(login);
        }

        [HttpPost]
        public IActionResult Edit(LoginCliente login)
        {
            if (ModelState.IsValid)
            {
                _loginClienteBL.Modificar(login);
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        public IActionResult Delete(int id)
        {
            var login = _loginClienteBL.Listar().FirstOrDefault(l => l.IdLoginCliente == id);
            if (login == null)
                return NotFound();

            return View(login);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _loginClienteBL.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
