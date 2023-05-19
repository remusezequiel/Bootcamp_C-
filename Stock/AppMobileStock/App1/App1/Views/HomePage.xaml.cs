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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        public void Button_About(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        public void Button_Articulos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ArticulosPage());
        }

        public void Button_Depositos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DepositosPage());
        }

        public void Button_Stock(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StockPage());
        }

    }
}