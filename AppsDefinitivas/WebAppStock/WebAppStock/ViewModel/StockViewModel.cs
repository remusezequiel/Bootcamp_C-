using CodigoComun.Entities.DTO;
using CodigoComun.Entities;
using CodigoComun.Modelo;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodigoComun.Modelo.DTO;
using CodigoComun.Negocio;

namespace WebAppStock.ViewModel
{
    public class StockViewModel
    {
        /***************  
         *  ATRIBUTOS 
         ***************/       
        public ArticuloDTO ArticulosDTO { get; set; }
        public DepositoDTO DepositosDTO { get; set; }
        public int idStock { get; set; }
        public StockDTO StockDTO { get; set; }
        public List<StockDTO> StockDTOs { get; set; }
        public List<ArticuloDTO> ArticulosDTOs { get; set; }
        public List<DepositoDTO> DepositosDTOs { get; set; }
       
        public SelectList selectArticulosList { get; set; }
        public SelectList selectDepositosList { get; set; }




        public string ArticuloName(int? idStockDTOAIdArticulo)
        {
            ArticuloDTO articuloDTO = new ArticuloDTO();
            ArticuloServices articuloServices = new ArticuloServices();

            articuloDTO = articuloServices.GetByID((int)idStockDTOAIdArticulo);
            return articuloDTO.Nombre;
        }
        public string ArticuloCode(int? idStockDTOAIdArticulo)
        {
            ArticuloDTO articuloDTO = new ArticuloDTO();
            ArticuloServices articuloServices = new ArticuloServices();

            articuloDTO = articuloServices.GetByID((int)idStockDTOAIdArticulo);
            return articuloDTO.Codigo;
        }
        public string DepositoName(int? idStockDTOAIdDeposito)
        {
            DepositoDTO depositoDTO = new DepositoDTO();
            DepositoServices depositoServices = new DepositoServices();

            depositoDTO = depositoServices.GetById((int)idStockDTOAIdDeposito);
            return depositoDTO.Nombre;
        }

    }
}
