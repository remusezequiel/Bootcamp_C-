using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    class StockABMViewModel : BaseViewModel
    {
        /**************************
         * PROPIEDADES/ATRIBUTOS
         **************************/
        #region Properties/ atributos

        public INavigation Navigation { get; set; }

        ApiStockServices _services = new ApiStockServices();

        public StockDTO StockDTO
        {
            get => GetPropertyValue<StockDTO>();
            set => SetPropertyValue(value);
        }
        #endregion


        /**************************
         * CONSTRUCTOR
         **************************/
        #region Constructor

        public StockABMViewModel()
        {
            Title = $"Stock";
            StockDTO = new StockDTO();
        }
        #endregion


        /**************
         *  COMMANDS 
         **************/
        #region Commands

        public Command Guardar
        {
            get
            {
                return new Command(async () => await GuardarStock());
            }
        }

        #endregion


        /**************
         *  METHODS 
         **************/
        #region Methods

        public async Task LoadStock(int Id)
        {
            if (IsBusy)
                return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {
                StockDTO = await _services.GetStockById(Id);

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Ocurrió un error " + ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GuardarStock()
        {
            try
            {
                ApiStockServices _services = new ApiStockServices();
                StockDTO.Origen = "ViewModel. Metodo: GuardarStock";
                StockDTO.Mensaje = "--";
                StockDTO = await _services.SendStock(StockDTO);

                if (StockDTO.HuboError == true)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error " + StockDTO.Mensaje, "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Confirmación", StockDTO.Mensaje, "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Ocurrio un error " + ex.Message, "Ok");
            }
        }

        #endregion

    }
}
