using CodigoComun.Entities;
using CodigoComun.Entities.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIRestStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositosController : ControllerBase
    {
        /************** 
         * ATRIBUTOS 
         **************/
        private DepositoServices depositosServices = new DepositoServices();



        /*********** 
         * METODOS 
         ***********/
        [HttpGet]
        public IEnumerable<DepositoDTO> Get()
        {
            return depositosServices.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        {    
            return Ok(depositosServices.GetById(id));
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] DepositoDTO depositoDTO) 
        {     
            return Ok(depositosServices.Add(depositoDTO));             
        }

        [HttpPut]
        public IActionResult Put([FromBody] DepositoDTO depositoDTO)
        {            
            return Ok(depositosServices.Update(depositoDTO));
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {            
            return Ok(depositosServices.Delete(id));
        }
    }
}
