using CodigoComun.Negocio;
using CodigoComun.Entities;

using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class DepositosController : Controller
    {
        public IActionResult Index()
        {
            DepositoServices ds = new DepositoServices();
            Deposito deposito = ds.GetDeposito(1);
            return View(deposito);
        }
    }
}
