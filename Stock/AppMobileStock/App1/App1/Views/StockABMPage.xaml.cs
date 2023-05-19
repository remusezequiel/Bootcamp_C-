using App1.Models;
using App1.Services;
using App1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StockABMPage : ContentPage
	{
        public ApiStockServices apiStockServices = new ApiStockServices();
        private static readonly StockABMViewModel stockABMViewModel = new StockABMViewModel();
        
         

		public StockABMPage ()
		{
			InitializeComponent ();

            stockABMViewModel.Navigation = Navigation;
            BindingContext = stockABMViewModel;
        }




    }
}