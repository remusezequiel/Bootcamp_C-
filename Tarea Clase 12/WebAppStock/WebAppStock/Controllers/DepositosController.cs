using CodigoComun.Negocio;
using CodigoComun.Entities;

using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class DepositosController : Controller
    {
        DepositoServices ds = new DepositoServices();
        public IActionResult Index()
        {
            //
            //Deposito deposito = ds.GetDeposito(1);
            //return View(deposito);
            var depositos = ds.GetTodosLosDepositos();
            return View(depositos);
        }

        public IActionResult Details()
        {         
            return View();
        }

    }
}
