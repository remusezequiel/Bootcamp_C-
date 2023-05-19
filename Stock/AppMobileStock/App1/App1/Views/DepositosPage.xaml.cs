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
    public partial class DepositosPage : ContentPage
    {

        public DepositosViewModel viewModel;


        public DepositosPage()
        {
            InitializeComponent();
            viewModel = new DepositosViewModel();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }

        /// <summary>
        ///     Mientras se carga la pantalla, 
        ///     se mostrara la lista de Depositos
        /// </summary>
        protected override async void OnAppearing()
        { 
            await viewModel.LoadDepositos();
        }


        public void Button_DepositosABM(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DepositosABMPage());
        }
    }
}