using Codigo_Comun.Negocio;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo.DTO;

namespace WebAppStock.ViewModel
{
    public class DepositosViewModel
    {
        /*************  
         *  ATRIBUTOS 
         *************/
        #region Atributos

        public ArticuloDTO ArticulosDTO { get; set; }
        public DepositoDTO depositoDTO { get; set; }
        public StockServices stockServices = new StockServices();
        public StockViewModel stockViewModel = new StockViewModel();
        #endregion

        /*************  
        *  METODOS 
        *************/
        #region Methods

        public StockViewModel StockDelDeposito(int idDeposito) 
        {
            //List<StockDTO> stockDTOs = new List<StockDTO>();
            //stockDTOs = stockServices.GetAll();            
            List<StockDTO> auxStockDTOs = new List<StockDTO>();
            StockViewModel stockViewModelAux = new StockViewModel();
            stockViewModel.StockDTOs = stockServices.GetAll();

            foreach (StockDTO stock in stockViewModel.StockDTOs) 
            {
                if (stock.IdDeposito == idDeposito) 
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
