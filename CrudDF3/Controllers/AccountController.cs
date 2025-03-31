using CrudDF3.Models;
using CrudDF3.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using BCrypt.Net; // Para el hasheo de contraseñas

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
                    .Include(u => u.IdRolNavigation) // INCLUYE LA RELACIÓN CON ROLES
                    .FirstOrDefault(u => u.CorreoUsuario == model.CorreoUsuario);

                if (user == null || !BCrypt.Net.BCrypt.Verify(model.ContraseñaUsuario, user.ContraseñaUsuario)) // Verificación con bcrypt
                {
                    ViewBag.ErrorMessage = "Usuario o contraseña incorrectos.";
                    return View(model);
                }

                // GUARDAR DATOS EN SESIÓN
                HttpContext.Session.SetString("idUsuario", user.IdUsuario.ToString());
                HttpContext.Session.SetString("nombreUsuario", user.NombreUsuario);
                HttpContext.Session.SetString("idRol", user.IdRol.ToString());

                // VERIFICAR QUE EL ROL NO SEA NULO
                if (user.IdRolNavigation != null)
                {
                    HttpContext.Session.SetString("nombreRol", user.IdRolNavigation.NombreRol);
                }

                return RedirectToAction("Index", "Home"); // REDIRIGIR A HOME
            }

            return View(model);
        }

        // MÉTODO PARA MOSTRAR EL FORMULARIO DE REGISTRO
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        // MÉTODO PARA REGISTRO, REUTILIZANDO "Create" DE UsuarioController
        [HttpPost]
        public async Task<IActionResult> Registrar(RegistrarViewModel model)
        {
            if (ModelState.IsValid)
            {
                // VALIDAR QUE EL CORREO NO EXISTA YA EN LA BASE DE DATOS
                var usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(u => u.CorreoUsuario == model.CorreoUsuario);
                if (usuarioExistente != null)
                {
                    ModelState.AddModelError("", "Este correo ya está registrado.");
                    return View(model);
                }

                // HASHEAR LA CONTRASEÑA ANTES DE GUARDAR
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.ContraseñaUsuario);

                // CREAR NUEVO USUARIO CON LOS DATOS DEL FORMULARIO
                var usuario = new Usuario
                {
                    CedulaUsuario = model.CedulaUsuario,
                    NombreUsuario = model.NombreUsuario,
                    ApellidoUsuario = model.ApellidoUsuario,
                    CorreoUsuario = model.CorreoUsuario,
                    Telefono = model.Telefono,
                    Direccion = model.Direccion,
                    ContraseñaUsuario = hashedPassword, // Guardar la contraseña hasheada
                    IdRol = 2, // CLIENTE
                    EstadoUsuario = true,
                    FechaCreacion = DateTime.Now
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login"); // REDIRIGE AL LOGIN TRAS REGISTRARSE
            }

            return View(model);
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

        // MÉTODO PARA MOSTRAR EL FORMULARIO DE RECUPERAR CONTRASEÑA
        public IActionResult Recuperar()
        {
            return View();
        }

        // POST: Procesar recuperación de contraseña
        [HttpPost]
        public async Task<IActionResult> Recuperar(string Correo)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.CorreoUsuario == Correo);
            if (usuario == null)
            {
                ViewData["Error"] = "El correo no está registrado.";
                return View();
            }

            // 🔹 Simular el código de recuperación
            Random rnd = new Random();
            int codigoRecuperacion = rnd.Next(100000, 999999); // Genera un código de 6 dígitos

            // 🔹 Guardar el código en la sesión
            HttpContext.Session.SetInt32("CodigoRecuperacion", codigoRecuperacion);
            HttpContext.Session.SetString("CorreoRecuperacion", Correo);

            // 🔹 Enviar el código por correo (simulado)
            EnviarCorreoRecuperacion(Correo, codigoRecuperacion);

            // 🔹 Simular "envío" mostrando el código en una alerta
            TempData["Codigo"] = codigoRecuperacion;

            return RedirectToAction("VerificarCodigo");
        }

        // Método para simular el envío del correo de recuperación
        private void EnviarCorreoRecuperacion(string correo, int codigo)
        {
            var fromAddress = new MailAddress("tuemail@dominio.com", "Sistema");
            var toAddress = new MailAddress(correo);
            const string subject = "Recuperación de Contraseña";
            string body = $"Tu código de recuperación es: {codigo}";

            using (var smtp = new SmtpClient("smtp.dominio.com", 587))
            {
                smtp.Credentials = new NetworkCredential("tuemail@dominio.com", "tucontraseña");
                smtp.EnableSsl = true;
                smtp.Send(fromAddress, toAddress, subject, body);
            }
        }

        // GET: Vista para ingresar el código
        public IActionResult VerificarCodigo()
        {
            if (!TempData.ContainsKey("Codigo"))
            {
                return RedirectToAction("Recuperar");
            }

            ViewData["Codigo"] = TempData["Codigo"]; // Mostrar el código en la alerta
            return View();
        }

        // POST: Verificar código y restablecer contraseña
        [HttpPost]
        public async Task<IActionResult> VerificarCodigo(int CodigoIngresado)
        {
            int? codigoGuardado = HttpContext.Session.GetInt32("CodigoRecuperacion");
            string correo = HttpContext.Session.GetString("CorreoRecuperacion");

            if (codigoGuardado == null || codigoGuardado != CodigoIngresado)
            {
                ViewData["Error"] = "Código incorrecto.";
                return View();
            }

            return RedirectToAction("Restablecer");
        }

        // GET: Vista para restablecer contraseña
        public IActionResult Restablecer()
        {
            return View();
        }

        // POST: Guardar nueva contraseña
        [HttpPost]
        public async Task<IActionResult> Restablecer(string NuevaContraseña)
        {
            string correo = HttpContext.Session.GetString("CorreoRecuperacion");

            if (string.IsNullOrEmpty(correo))
            {
                return RedirectToAction("Recuperar");
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.CorreoUsuario == correo);
            if (usuario == null)
            {
                return RedirectToAction("Recuperar");
            }

            // HASHEAR LA NUEVA CONTRASEÑA ANTES DE GUARDAR
            usuario.ContraseñaUsuario = BCrypt.Net.BCrypt.HashPassword(NuevaContraseña);
            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }
    }
}
