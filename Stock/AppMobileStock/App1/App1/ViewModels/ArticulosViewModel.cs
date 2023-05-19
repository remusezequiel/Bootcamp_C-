using App1.Models;
using App1.Services;
using App1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class ArticulosViewModel : BaseViewModel
    {
        /**************************
         * PROPIEDADES/ATRIBUTOS
         **************************/
        #region Properties/Atributos
        public INavigation Navigation { get; set; }
        ApiArticulosServices _service = new ApiArticulosServices();

        /// <summary>
        ///     Lista especifica de Xamarim.Forms. 
        ///     Trae la lista de Depositos Existente
        /// </summary>
        public ObservableCollection<ArticuloDTO> Articulos
        {
            get => GetPropertyValue<ObservableCollection<ArticuloDTO>>();
            set => SetPropertyValue(value);
        }

        #endregion


        /**************************
         * CONSTRUCTOR
         **************************/
        #region Constructor
        public ArticulosViewModel()
        {
            Articulos = new ObservableCollection<ArticuloDTO>();
            Title = $"Listado Articulos";
        }
        #endregion

        /**************
         *  COMMANDS 
         **************/
        #region Commands
        public Command NuevoArticulo
        {
            get
            {
                return new Command(async () => await GoToABMPage());
            }
        }
        #endregion


        /**************
         *  METHODS 
         **************/
        #region Methods

        /// <summary>
        ///    Se encarga de Cargar los Articulos
        /// </summary>
        /// <returns></returns>
        public async Task LoadArticulos()
        {
            if (IsBusy)
                return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {
                var articulosList = await _service.GetArticulos();
                Articulos = new ObservableCollection<ArticuloDTO>(articulosList);
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
        ///     Vuelve a la pagina ArticulosABMPage
        /// </summary>
        /// <returns></returns>
        public async Task GoToABMPage()
        {
            await Navigation.PushAsync(new ArticulosABMPage());
        }
        #endregion

    }
}
