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
    public class DepositosViewModel : BaseViewModel
    {
        #region Properties/Atributos 
        
        public INavigation Navigation { get; set; }
        ApiDepositosServices _service = new ApiDepositosServices();

        /// <summary>
        ///     Lista especifica de Xamarim.Forms. 
        ///     Trae la lista de Depositos Existente
        /// </summary>
        public ObservableCollection<DepositoDTO> Depositos
        {
            get => GetPropertyValue<ObservableCollection<DepositoDTO>>();
            set => SetPropertyValue(value);
        }

        #endregion

        #region Constructor
        public DepositosViewModel() 
        {
            Depositos = new ObservableCollection<DepositoDTO>();
            Title = $"Listado Depositos";
        }
        #endregion

        #region Commands 
        public Command NuevoDeposito
        {
            get {
                return new Command(async () => await GoToABMPage());
            }
        }
        #endregion

        #region Methods 
        
        /// <summary>
        ///    Se encarga de Cargar los Depositos
        /// </summary>
        /// <returns></returns>
        public async Task LoadDepositos() 
        {
            if (IsBusy)
                return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {
                var depositosList = await _service.GetDepositos();
                Depositos = new ObservableCollection<DepositoDTO>(depositosList);
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
        ///     Vuelve a la pagina DepositosABMPage
        /// </summary>
        /// <returns></returns>
        public async Task GoToABMPage() 
        {
            await Navigation.PushAsync(new DepositosABMPage());
        }
        
        #endregion
    }
}
