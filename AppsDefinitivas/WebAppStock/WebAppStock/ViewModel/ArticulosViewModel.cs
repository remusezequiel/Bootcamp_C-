using Codigo_Comun.Negocio;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo.DTO;

namespace WebAppStock.ViewModel
{
    public class ArticulosViewModel
    {
        /*************  
         *  ATRIBUTOS 
         *************/
        #region Atributos

        public StockServices stockServices = new StockServices();
        public StockViewModel stockViewModel = new StockViewModel();
        #endregion

        /*************  
        *  METODOS 
        *************/
        #region Methods

        public StockViewModel StockDelArticulo(int idArticulo)
        {            
            List<StockDTO> auxStockDTOs = new List<StockDTO>();
            StockViewModel stockViewModelAux = new StockViewModel();
            
            stockViewModel.StockDTOs = stockServices.GetAll();
            foreach (StockDTO stock in stockViewModel.StockDTOs)
            {   
                if (stock.IdArticulo == idArticulo)
                {
                    auxStockDTOs.Add(stockServices.GetById(stock.Id));
                }
            }
            stockViewModelAux.StockDTOs = auxStockDTOs;
            return stockViewModelAux;
        }
        #endregion
    }
}
