using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.Views;

namespace App1.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        public void Button_Home(object sender, EventArgs e) 
        {
            Navigation.PushAsync(new HomePage());
        }
        public  void Button_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Aviso", "Hola", "OK");
            Navigation.PushAsync(new PrimeraAuxPage());
        }
        public void Button_Segunda_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Aviso", "Hola", "OK");
            Navigation.PushAsync(new SegundaPage());
        }
        public void Button_DepositosPage(object sender, EventArgs e)
        {
            //DisplayAlert("Aviso", "Hola", "OK");
            Navigation.PushAsync(new DepositosPage());
        }
    }
}