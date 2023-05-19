using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class ArticulosABMViewModel : BaseViewModel
    {
        /**************************
         * PROPIEDADES/ATRIBUTOS
         **************************/
        #region Properties/Atributos
        public INavigation Navigation { get; set; }

        ApiArticulosServices _services = new ApiArticulosServices();

        public ArticuloDTO ArticuloDTO
        {
            get => GetPropertyValue<ArticuloDTO>();
            set => SetPropertyValue(value);
        }

        #endregion


        /**************************
         * CONSTRUCTOR
         **************************/
        #region Constructor
        public ArticulosABMViewModel() 
        {
            Title = $"Articulos";
            ArticuloDTO = new ArticuloDTO();
        }
        #endregion


        /**************************
         * COMMANDS
         **************************/
        #region Commands
        public Command Guardar
        {
            get
            {
                return new Command(async () => await GuardarArticulo());
            }
        }
        #endregion

        /**************************
         * METHODS
         **************************/
        #region Methods
        public async Task LoadArticulo(int Id)
        {
            if (IsBusy)
                return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {
                ArticuloDTO = await _services.GetArticuloById(Id);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Cuidado!", "Varifique que los campos no esten vacios.", "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GuardarArticulo()
        {
            try
            {                
                ArticuloDTO.Origen = "ViewModel. Metodo: GuardarArticulo";
                ArticuloDTO.Mensaje = "--";
                ArticuloDTO = await _services.SendArticulo(ArticuloDTO);

                if (ArticuloDTO.HuboError == true)
                {
                    await Application.Current.MainPage.DisplayAlert("Cuidado!", ArticuloDTO.Mensaje, "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Confirmación", ArticuloDTO.Mensaje, "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Cuidado!", "Varifique que los campos no esten vacios.", "Ok");
            }
        }
        #endregion
    }
}
