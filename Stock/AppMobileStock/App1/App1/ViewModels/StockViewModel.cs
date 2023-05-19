using App1.Models;
using App1.Services;
using App1.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class StockViewModel : BaseViewModel
    {
        /**************************
         * PROPIEDADES/ATRIBUTOS
         **************************/
        #region Properties/Atributos
       
        public INavigation Navigation { get; set; }
        
        ApiStockServices _service = new ApiStockServices();
       // ApiArticulosServices apiArticuloService = new ApiArticulosServices();
        ApiDepositosServices apiDepositoService = new ApiDepositosServices();
        ApiStockManagerServices apiStockManagerServices = new ApiStockManagerServices();

        public StockDTO StockDTO
        {
            get => GetPropertyValue<StockDTO>();
            set => SetPropertyValue(value);
        }

        public String CadenaCantidad
        {
            get => GetPropertyValue<String>();
            set => SetPropertyValue(value);
        }
       
        public ArticuloDTO ArticuloDTO
        {
            get => GetPropertyValue<ArticuloDTO>();
            set => SetPropertyValue(value);
        }

        public DepositoDTO DepositoDTO
        {
            get => GetPropertyValue<DepositoDTO>();
            set => SetPropertyValue(value);
        }

        public ObservableCollection<StockDTO> Stock
        {
            get => GetPropertyValue<ObservableCollection<StockDTO>>();
            set => SetPropertyValue(value);
        }

        public ObservableCollection<DepositoDTO> Deposito
        {
            get => GetPropertyValue<ObservableCollection<DepositoDTO>>();
            set => SetPropertyValue(value);
        }

        /*
        public ObservableCollection<ArticuloDTO> Articulo
        {
            get => GetPropertyValue<ObservableCollection<ArticuloDTO>>();
            set => SetPropertyValue(value);
        }
        */
        #endregion


        /**************************
         * CONSTRUCTOR
         **************************/
        #region Constructor
        public StockViewModel()
        {
            Stock = new ObservableCollection<StockDTO>();
            //Articulo = new ObservableCollection<ArticuloDTO>();
            Deposito = new ObservableCollection<DepositoDTO>();
            CadenaCantidad = " ";
            Title = $"Listado Stock";
            StockDTO = new StockDTO();
            ArticuloDTO = new ArticuloDTO();
            //DepositoDTO = new DepositoDTO();
        }
        #endregion

        /**************
         *  COMMANDS 
         **************/
        #region Commands
        /*
        public Command NuevoStock
        {
            get
            {
                return new Command(async () => await GoToABMPage());
            }
        }
        */
        public Command Ingreso
        {
            get
            {
                return new Command(async () => await GuardarStock(1));
            }
        }

        public Command Egreso
        {
            get
            {
                return new Command(async () => await GuardarStock(2));
            }
        }

        #endregion


        /**************
         *  METHODS 
         **************/
        #region Methods

        /// <summary>
        ///    Se encarga de Cargar los Stock
        /// </summary>
        /// <returns></returns>
        public async Task LoadStock()
        {
            if (IsBusy)
                return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {
                var stockList = await _service.GetStock();
                Stock = new ObservableCollection<StockDTO>(stockList);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Ocurrio un error:" + ex.Message,
                    "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        
        /*
        public async Task LoadArticulo()
        {
            if (IsBusy)
                return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {
                var articuloList = await apiArticuloService.GetArticulos();
                Articulo = new ObservableCollection<ArticuloDTO>(articuloList);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Ocurrio un error:" + ex.Message,
                    "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        */     
        
        /// <summary>
        ///      Se encarga de cargar los Depositos
        /// </summary>
        /// <returns></returns>
        public async Task LoadDeposito()
        {
            if (IsBusy)
                return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {
                var depositosList = await apiDepositoService.GetDepositos();
                Deposito = new ObservableCollection<DepositoDTO>(depositosList);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Ocurrio un error:" + ex.Message,
                    "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }


        
        /// <summary>
        ///     Realiza la carga del StockManager a partir de los datos 
        ///     tomados de los Entrys y el Picker. Coloca valores convenientes
        ///     para HuboError, Mensaje y Origen.
        /// </summary>
        /// <returns></returns>
        private StockManager CargarStockManager() 
        {
            decimal cantidad = 0;
            bool canConvert = decimal.TryParse(CadenaCantidad, out cantidad);
            StockManager stockManager = new StockManager();
            if (canConvert == true)
            {
                cantidad = Convert.ToDecimal(CadenaCantidad);
                stockManager.CodigoArticulo = ArticuloDTO.Codigo;
                stockManager.Cantidad = cantidad;
                stockManager.IdDeposito = DepositoDTO.Id;
                stockManager.HuboError = false;
                stockManager.Mensaje = "--";
                stockManager.Origen = "Cargame";
            }
            else {
                stockManager.Origen = "NoMeCargues";
                stockManager.Mensaje = "Ingresaste caracteres en el ingreso de Cantidades.\n Las Cantidades deben ser Numericas";
            }
            
            return stockManager;
        }
        
        /// <summary>
        ///     Se encarga de hacer el pase al post con
        ///     la acción indicada para ingresar stock
        /// </summary>
        /// <returns></returns>
        private async Task GuardarStock(int accion)
        {
            try
            {
                
                StockManager stockManager = CargarStockManager();
                if (stockManager.Origen == "Cargame")
                {
                    stockManager.Accion = accion;

                    stockManager = await apiStockManagerServices.SendStockManager(stockManager);
                    if (stockManager.HuboError == true)
                    {
                        await Application.Current.MainPage.DisplayAlert("Cuidado!",
                             stockManager.Mensaje, "ok");
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Confirmación",
                            stockManager.Mensaje, "ok");
                    }
                }
                else {
                    await Application.Current.MainPage.DisplayAlert("Cuidado!",
                            stockManager.Mensaje, "ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Cuidado!", "Verifique que no hallan campos vacios" , "Ok");
            }
        }
        
        #endregion


    }
}
