using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class DepositosABMViewModel : BaseViewModel
    {
        /**************************
         * PROPIEDADES/ATRIBUTOS
         **************************/
        #region Properties/ atributos

        public INavigation Navigation { get; set; }

        ApiDepositosServices _services = new ApiDepositosServices();

        public DepositoDTO DepositoDTO
        {
            get => GetPropertyValue<DepositoDTO>();
            set => SetPropertyValue(value);
        }
        #endregion


        /**************************
         * CONSTRUCTOR
         **************************/
        #region Constructor

        public DepositosABMViewModel()
        {            
            Title = $"Depositos";
            DepositoDTO = new DepositoDTO();
        }
        #endregion


        /**************
         *  COMMANDS 
         **************/
        #region Commands

        public Command Guardar
        {
            get
            {
                return new Command(async () => await GuardarDeposito());
            }
        }

        #endregion

            
        /**************
         *  METHODS 
         **************/
        #region Methods
        
        public async Task LoadDeposito(int Id)
        {
            if (IsBusy)
                return;

            await Task.Delay(100);
            IsBusy = true;

            try
            {
                DepositoDTO = await _services.GetDepositoById(Id);
                
            }
            catch (Exception ex)
            { 
                await Application.Current.MainPage.DisplayAlert("Error!", "Ocurrió un error " + ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task GuardarDeposito()
        {
            try
            {
                ApiDepositosServices _services = new ApiDepositosServices();
                DepositoDTO.Origen = "ViewModel. Metodo: GuardarDeposito";
                DepositoDTO.Mensaje = "--";
                DepositoDTO = await _services.SendDeposito(DepositoDTO);

                if (DepositoDTO.HuboError==true)
                {
                    await Application.Current.MainPage.DisplayAlert("Cuidado!", DepositoDTO.Mensaje, "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Confirmación", DepositoDTO.Mensaje, "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Cuidado!", "Varifique que los campos no esten vacios.", "Ok");
            }
        #endregion
        }




    }
}
