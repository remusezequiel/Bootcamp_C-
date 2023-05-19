using Codigo_Comun.Entities.DTO;
using Codigo_Comun.Negocio;
using CodigoComun.Entities.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIRestStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockManagerController : Controller
    {

        #region Atributos
        private StockManagerServices stockManagerServices = new StockManagerServices();
        #endregion

        [HttpPost]
        public IActionResult Post([FromBody] StockManager stockManager)
        {
            //return Ok(stockServices.Add(stockDTO));
            if (stockManager.Accion == 1)
            {
                return Ok(stockManagerServices.IncomeOrAdd(stockManager));
            }
            else {
                return Ok(stockManagerServices.Discharge(stockManager));
            }
        }
    }
}
