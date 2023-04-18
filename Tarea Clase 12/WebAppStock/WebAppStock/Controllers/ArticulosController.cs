using CodigoComun.Modelo;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class ArticulosController : Controller
    {
        ArticuloServices articuloServices = new ArticuloServices();
        public IActionResult Index()
        {
            var articulos = articuloServices.GetTodosPorID();            
            return View(articulos);
        }
    }
}
