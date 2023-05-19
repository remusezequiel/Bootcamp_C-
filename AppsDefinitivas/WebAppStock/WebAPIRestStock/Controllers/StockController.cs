using Codigo_Comun.Negocio;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIRestStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        /************** 
        * ATRIBUTOS 
        **************/
        private StockServices stockServices = new StockServices();


        /*********** 
         * METODOS 
         ***********/
        [HttpGet]
        public IEnumerable<StockDTO> Get()
        {
            return stockServices.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(stockServices.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] StockDTO stockDTO)
        {
            return Ok(stockServices.Add(stockDTO));
            //return Ok(stockServices.IncomeOrAdd(stockDTO));
        }

        [HttpPut]
        public IActionResult Put([FromBody] StockDTO stockDTO)
        {
            return Ok(stockServices.Update(stockDTO));
            //return Ok(stockServices.Discharge(stockDTO));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(stockServices.Delete(id));
        }
    }
}
