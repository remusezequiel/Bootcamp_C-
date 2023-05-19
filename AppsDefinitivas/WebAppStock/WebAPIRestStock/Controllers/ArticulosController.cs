using CodigoComun.Datos.Repository;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPIRestStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        /************** 
         * ATRIBUTOS 
         **************/
        private ArticuloServices articuloServices = new ArticuloServices();


        /*********** 
         * METODOS 
         ***********/
        [HttpGet]
        public IEnumerable<ArticuloDTO> Get()
        {
            return articuloServices.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(articuloServices.GetByID(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ArticuloDTO articuloDTO)
        {
            return Ok(articuloServices.Add(articuloDTO));
        }

        [HttpPut]
        public IActionResult Put([FromBody] ArticuloDTO articuloDTO)
        {
            return Ok(articuloServices.Update(articuloDTO));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           return Ok(articuloServices.Delete(id));
        }

    }
}
