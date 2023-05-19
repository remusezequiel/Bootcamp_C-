using CodigoComun.Entities;
using CodigoComun.Modelo;
using CodigoComun.Modelo.DTO;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;
using WebAppStock.ViewModel;

namespace WebAppStock.Controllers
{
    public class ArticulosController : Controller
    {
        /************* 
         * ATRIBUTOS
         *************/
        private ArticuloServices articuloServices = new ArticuloServices();
        private ArticuloDTO articuloDTO = new ArticuloDTO();
        private List<ArticuloDTO> articulosDTO = new List<ArticuloDTO>();
        private ArticulosViewModel viewModel = new ArticulosViewModel();
        private StockViewModel stockViewModel = new StockViewModel();

        [HttpGet]
        public IActionResult Index()
        {
            var articulos = articuloServices.GetAll();
            //var articulos = articuloDTO.GetAllArticulos(articulosDTO);
            return View(articulos);
        }

        /************  
        *  CREATE 
        ************/
        [HttpGet]
        public IActionResult Create()
        {   
            ArticuloDTO articuloDTO = new ArticuloDTO();
            return View(articuloDTO);
        }
        [HttpPost]
        public IActionResult Create(ArticuloDTO articuloDTOToAdd)
        {
            //Articulo articulo = new Articulo();
            articuloDTO = articuloServices.Add(articuloDTOToAdd);            

            if (articuloDTO.HuboError == false)
            {
                //ViewBag.Mensaje(articuloDTO.Mensaje);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensaje = articuloDTO.Mensaje;
                return View(articuloDTO);
            }
        }


        /************  
        *   EDIT 
        ************/
        [HttpGet]
        public IActionResult Edit(int id)
        {            
            return View(articuloServices.GetByID(id));
        }
        [HttpPost]
        public IActionResult Edit(ArticuloDTO objetToModify)
        {
            Articulo articulo = new Articulo();
            articuloDTO = articuloServices.Update(objetToModify);

            if (articuloDTO.HuboError == false)
            {
                articuloDTO.Mensaje = "El Articulo fue modificado con exito";
                return RedirectToAction("Index");
            }
            else
            {
                articuloDTO.Mensaje = "No se pudo Modificar el Articulo";
                ViewBag.Mensaje = articuloDTO.Mensaje;
                return View(articuloDTO);
            }
        }

        /************  
        *   DELETE 
        ************/
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var articulos = articuloServices.GetAll();
            Articulo articulo = new Articulo();
            articuloDTO = articuloServices.Delete(id);
            if (articuloDTO.HuboError == false)
            {
                //articuloDTO.Mensaje = "Articulo Eliminado con Exito";
                ViewBag.Mensaje = articuloDTO.Mensaje;
                return View(articuloDTO);
            }
            else
            {
                //articuloDTO.Mensaje = "No se pudo Eliminar el Articulo";
                ViewBag.Mensaje = articuloDTO.Mensaje;
                return View(articuloDTO);
            }
        }

        /********************  
        *   StockDeArticulo 
        ********************/
        [HttpGet]
        public IActionResult StockDeArticulo(int id)
        {
            stockViewModel = viewModel.StockDelArticulo(id);
            return View(stockViewModel);
        }
    }
}
