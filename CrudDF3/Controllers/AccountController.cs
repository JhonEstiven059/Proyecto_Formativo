using CrudDF3.Models;
using CrudDF3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CrudDF3.Controllers
{
    public class AccountController : Controller
    {
        private readonly CrudDf3Context _context;

        public AccountController(CrudDf3Context context)
        {
            _context = context;
        }

        // MÉTODO PARA MOSTRAR EL FORMULARIO DE LOGIN
        public IActionResult Login()
        {
            return View();
        }

        // MÉTODO PARA PROCESAR EL LOGIN
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuarios
                    .FirstOrDefault(u => u.CorreoUsuario == model.CorreoUsuario && u.ContraseñaUsuario == model.ContraseñaUsuario);

                if (user != null)
                {
                    // GUARDAR DATOS EN LA SESIÓN
                    HttpContext.Session.SetString("idUsuario", user.IdUsuario.ToString());
                    HttpContext.Session.SetString("nombreUsuario", user.NombreUsuario);
                    HttpContext.Session.SetString("idRol", user.IdRol.ToString());

                    return RedirectToAction("Index", "Home"); // REDIRIGIR A LA PÁGINA PRINCIPAL
                }
                else
                {
                    ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
                }
            }

            return View(model);
        }

        // MÉTODO PARA REGISTRO, REUTILIZANDO "Create" DE UsuarioController
        public IActionResult Registrar()
        {
            return RedirectToAction("Create", "Usuario", new { idRol = 2 }); // REGISTRAR COMO CLIENTE
        }

        // MÉTODO PARA CERRAR SESIÓN
        public IActionResult Logout()
        {
            // LIMPIAR LA SESIÓN
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("IdUsuario");

            // REDIRIGIR AL LOGIN
            return RedirectToAction("Login", "Account");
        }
    }
}
