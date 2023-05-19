using App1.Models;
using App1.Services;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StockPage : ContentPage
	{
        #region Atributos
        public ApiStockServices apiStockServices = new ApiStockServices();
        public StockViewModel viewModel;
        #endregion

        #region Contructor
        public StockPage ()
		{
			InitializeComponent ();
            viewModel = new StockViewModel();
            viewModel.Navigation = Navigation;
			BindingContext = viewModel;
		}
        #endregion

        #region Metodos
        
        /// <summary>
        ///     Mientras se carga la pantalla, 
        ///     se mostrara la lista de Depositos
        /// </summary>
        protected override async void OnAppearing()
        {
            await viewModel.LoadStock();            
            await viewModel.LoadDeposito();
        }

        /// <summary>
        ///  Se encarga de tomar el Deposito seleccionado
        ///  en el Picker. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void IdDepositoPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            DepositoDTO selectedItem = (DepositoDTO)IdDepositoPicker.SelectedItem;
            viewModel.DepositoDTO = selectedItem;
        }

        #endregion
        
        
        //public void Button_StockABM(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new StockABMPage());
        //}
    }
}