using CodigoComun.Modelo;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class ArticulosController : Controller
    {
        public IActionResult Index()
        {   
            ArticuloServices articuloServices = new ArticuloServices();
            Articulo articulo = new Articulo();
            articulo = articuloServices.GetPorID(3);
            return View(articulo);
        }
    }
}
