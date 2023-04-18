using Codigo_Comun.Negocio;
using CodigoComun.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{       
    public class StockController : Controller
    {
        StockServices stockServices = new StockServices();

        public IActionResult Index()
        {
            var stock = stockServices.GetTodosLosStocks();
            return View(stock);
        }
    }
}
