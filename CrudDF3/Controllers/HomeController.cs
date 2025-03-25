using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewData["MostrarNav"] = false; // Cambiar a true si el usuario está autenticado
        return View();
    }

    public IActionResult Dashboard()
    {
        ViewData["MostrarNav"] = true; // Mostrar el nav en el dashboard
        return View();
    }
}
