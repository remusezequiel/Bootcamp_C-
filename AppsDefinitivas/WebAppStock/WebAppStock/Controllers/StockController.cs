using Codigo_Comun.Negocio;
using CodigoComun.Entities;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo;
using CodigoComun.Negocio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppStock.ViewModel;

namespace WebAppStock.Controllers
{       
    public class StockController : Controller
    {
        /************* 
        * ATRIBUTOS
        *************/
        public StockServices stockServices = new StockServices();
        public ArticuloServices articuloServices = new ArticuloServices();
        public DepositoServices depositoServices = new DepositoServices();
        public StockViewModel stockViewModel = new StockViewModel();

        /************* 
        *   INDEX
        *************/
        public IActionResult Index()
        {            
            stockViewModel.StockDTOs = stockServices.GetAll();            
            return View(stockViewModel);
        }

        /************* 
        *   CREATE
        *************/
        [HttpGet]
        public IActionResult Create() 
        {
            stockViewModel.ArticulosDTOs = articuloServices.GetAll();            
            stockViewModel.selectArticulosList = new SelectList(stockViewModel.ArticulosDTOs, "Id", "Nombre");
            
            stockViewModel.DepositosDTOs = depositoServices.GetAll();
            stockViewModel.selectDepositosList = new SelectList(stockViewModel.DepositosDTOs, "Id", "Nombre");

            return View(stockViewModel);
        }
        [HttpPost]
        public IActionResult Create(StockViewModel stockViewModel) 
        {
            StockDTO stockDTO = stockServices.Add(stockViewModel.StockDTO);
            
            if (stockDTO.HuboError == false)
            {
                ViewBag.Mensaje = stockDTO.Mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                stockViewModel.StockDTOs = stockServices.GetAll();
                stockViewModel.ArticulosDTOs = articuloServices.GetAll();
                stockViewModel.selectArticulosList = new SelectList(stockViewModel.ArticulosDTOs, "Id", "Nombre");

                stockViewModel.DepositosDTOs = depositoServices.GetAll();
                stockViewModel.selectDepositosList = new SelectList(stockViewModel.DepositosDTOs, "Id", "Nombre");
                ViewBag.Mensaje = stockDTO.Mensaje;
                return View(stockViewModel);
            }
        }

        /************* 
        *   EDIT
        *************/
        [HttpGet]
        public IActionResult Edit(int id)
        {
            stockViewModel.idStock = id;
            StockDTO aux = stockServices.GetById(id);
            stockViewModel.StockDTO = aux;

            stockViewModel.ArticulosDTOs = articuloServices.GetAll();
            stockViewModel.selectArticulosList = new SelectList(stockViewModel.ArticulosDTOs, "Id", "Nombre");

            stockViewModel.DepositosDTOs = depositoServices.GetAll();
            stockViewModel.selectDepositosList = new SelectList(stockViewModel.DepositosDTOs, "Id", "Nombre");

            
            return View(stockViewModel);
        }
        [HttpPost]
        public IActionResult Edit(int id, StockViewModel stockViewModel)
        {
            
            stockViewModel.StockDTO.Id = id;
            StockDTO stockDTO = stockServices.Update(stockViewModel.StockDTO);
            
            if (stockDTO.HuboError == false)
            {
                //ViewBag.Mensaje = stockDTO.Mensaje;
                return RedirectToAction("Index");
                //return View();
            }
            else
            {
                stockViewModel.ArticulosDTOs = articuloServices.GetAll();
                stockViewModel.selectArticulosList = new SelectList(stockViewModel.ArticulosDTOs, "Id", "Nombre");

                stockViewModel.DepositosDTOs = depositoServices.GetAll();
                stockViewModel.selectDepositosList = new SelectList(stockViewModel.DepositosDTOs, "Id", "Nombre");
                ViewBag.Mensaje = stockDTO.Mensaje;
                return View(stockViewModel);
            }
        }

        /************  
        *   DELETE 
        ************/
        [HttpGet]
        public IActionResult Delete(int id)
        {
            stockViewModel.StockDTO = stockServices.Delete(id);
            if (stockViewModel.StockDTO.HuboError == false)
            {

                ViewBag.Mensaje = stockViewModel.StockDTO.Mensaje;
                return View(stockViewModel);
            }
            else
            {
                ViewBag.Mensaje = stockViewModel.StockDTO.Mensaje;
                return View(stockViewModel);
            }
        }

    }
}
