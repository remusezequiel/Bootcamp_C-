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
	public partial class ArticulosPage : ContentPage
	{
        public ArticulosViewModel viewModel;

        public ArticulosPage ()
		{
			InitializeComponent ();
            viewModel = new ArticulosViewModel ();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
		}

        /// <summary>
        ///     Mientras se carga la pantalla, 
        ///     se mostrara la lista de Articulos
        /// </summary>
        protected override async void OnAppearing()
        {
            await viewModel.LoadArticulos();
        }


        public void Button_ArticulosABM(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ArticulosABMPage());
        }
    }
}