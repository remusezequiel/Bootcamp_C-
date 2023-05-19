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
    public partial class DepositosABMPage : ContentPage
    {
        public ApiDepositosServices apiDepositosServices = new ApiDepositosServices();
        public DepositosABMViewModel viewModel; 


        public DepositosABMPage()
        {
            InitializeComponent();
            viewModel = new DepositosABMViewModel();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }

        /*
        public async void Button_AddDepositos(object sender, EventArgs e) 
        {
            try {
                DepositoDTO depositoDTOAdd = new DepositoDTO();
                depositoDTOAdd.Nombre = txtNombre.Text;
                depositoDTOAdd.Direccion = txtDireccion.Text;
                depositoDTOAdd.Capacidad = Convert.ToInt32(txtCapacidad.Text);
                depositoDTOAdd.Mensaje = "--";
                depositoDTOAdd.Origen = "Button_AddDepositos";

                
                await apiDepositosServices.SendDeposito(depositoDTOAdd);
                if (depositoDTOAdd.HuboError == false) {
                    await DisplayAlert("Confirmación", "Se ha agregado el deposito", "OK");
                }
                else{
                    await DisplayAlert("Error", 
                        "No se pudo agregar el deposito", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error",ex.Message,"OK");
              
            }
        }
         */

    }
}