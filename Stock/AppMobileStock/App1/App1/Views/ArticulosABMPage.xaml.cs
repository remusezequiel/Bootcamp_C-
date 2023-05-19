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
	public partial class ArticulosABMPage : ContentPage
	{
        public ApiArticulosServices apiArticulosServices = new ApiArticulosServices();
 
        public ArticulosABMViewModel viewModel;

        public ArticulosABMPage ()
		{
			InitializeComponent ();
            viewModel = new ArticulosABMViewModel ();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
                
        }

        /*
        public async void Button_AddArticulos(object sender, EventArgs e)
        {
            try
            {
                string MinStockAux = txtMinimoStock.Text.Replace(",", ".");
                string PrecioAux = txtPrecio.Text.Replace(",", ".");

                ArticuloDTO articuloDTOAdd = new ArticuloDTO();
                articuloDTOAdd.Nombre = txtNombre.Text;
                articuloDTOAdd.Marca = txtMarca.Text;
                articuloDTOAdd.MinimoStock = Convert.ToDecimal(txtMinimoStock.Text);
                articuloDTOAdd.Proveedor = txtProveedor.Text;
                articuloDTOAdd.Precio = Convert.ToDecimal(txtPrecio.Text);
                articuloDTOAdd.Codigo = txtCodigo.Text;
                articuloDTOAdd.Mensaje = "--";
                articuloDTOAdd.Origen = "Button_AddArticulos";
                
                var datosAdd = await apiArticulosServices.SendArticulo(articuloDTOAdd);

                if (datosAdd.HuboError == false)
                {
                    await DisplayAlert("Confirmación", "Se ha agregado el Articulo", "OK");
                }
                else
                {
                    await DisplayAlert("Error",
                        "No se pudo agregar el Articulo", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");

            }
        }*/
    }
}