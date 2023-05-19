using CodigoComun.Entities.DTO;
using CodigoComun.Negocio;
using CodigoComun.Entities;

using Microsoft.AspNetCore.Mvc;
using CodigoComun.Modelo.DTO;
using WebAppStock.ViewModel;

namespace WebAppStock.Controllers
{
    public class DepositosController : Controller
    {
        /**************  
        *   ATRIBUTOS 
        ***************/
        private DepositoServices depositoServices = new DepositoServices();
        private DepositoDTO depositoDTO = new DepositoDTO();
        private List<DepositoDTO> depositosDTO = new List<DepositoDTO>();
        private DepositosViewModel viewModel = new DepositosViewModel();
        private StockViewModel stockViewModel = new StockViewModel();


        /************  
        *   INDEX 
        ************/
        [HttpGet]
        public IActionResult Index()
        {
            return View(depositoServices.GetAll());
        }

        /************  
        *   CREATE 
        ************/
        [HttpGet]
        public IActionResult Create() 
        {
            return View(depositoDTO);
        }
        [HttpPost]
        public IActionResult Create(DepositoDTO depositoDTOToAdd)
        {
            
            depositoDTO = depositoServices.Add(depositoDTOToAdd);            

            if (depositoDTO.HuboError == false)
            {
                ViewBag.Mensaje = depositoDTO.Mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensaje = depositoDTO.Mensaje;
                return View(depositoDTO);
            }
        }

        /************  
        *   EDIT 
        ************/

        [HttpGet]
        public IActionResult Edit(int id)
        {            
            return View(depositoServices.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(DepositoDTO depositoToModify)
        {
            depositoDTO = depositoServices.Update(depositoToModify);

            if (depositoDTO.HuboError == false)
            {
                depositoDTO.Mensaje = "Deposito Modificado con exito";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Mensaje = depositoDTO.Mensaje;
                return View(depositoDTO);
            }
        }


        /************  
        *   DELETE 
        ************/
        [HttpGet]
        public IActionResult Delete(int id) 
        {
            depositoDTO = depositoServices.Delete(id);
            if (depositoDTO.HuboError == false) {

                ViewBag.Mensaje = depositoDTO.Mensaje;
                return View(depositoDTO);
            }
            else {
                ViewBag.Mensaje = depositoDTO.Mensaje;
                return View(depositoDTO);
            }
        }

        /********************  
        *   StockDeDeposito 
        ********************/
        [HttpGet]
        public IActionResult StockDeDeposito(int id) 
        {
            stockViewModel = viewModel.StockDelDeposito(id);
            return View(stockViewModel);
        }

    }
}
