using CrudDF3.Models;
using CrudDF3.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CrudDF3.Controllers
{
    public class AccountController : Controller
    {
        private readonly CrudDf3Context _context;

        public AccountController(CrudDf3Context context)
        {
            _context = context;
        }

        // MÉTODO PARA MOSTRAR LA VISTA DE LOGIN
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
                    HttpContext.Session.SetString("IdUsuario", user.IdUsuario.ToString());
                    HttpContext.Session.SetString("NombreUsuario", user.NombreUsuario);

                    return RedirectToAction("Index", "Home"); // REDIRIGIR A LA PÁGINA PRINCIPAL
                }
                else
                {
                    ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            // LIMPIAR LA SESIÓN
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("IdUsuario");

            // ELIMINAR AUTENTICACIÓN
            await HttpContext.SignOutAsync();

            // REDIRIGIR AL LOGIN
            return RedirectToAction("Login", "Account");
        }
    }
}
