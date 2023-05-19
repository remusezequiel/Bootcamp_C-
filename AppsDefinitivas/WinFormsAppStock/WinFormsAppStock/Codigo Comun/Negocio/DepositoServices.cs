using Codigo_Comun.Negocio;
using CodigoComun.Datos.Repository;
using CodigoComun.Entities;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo;
using CodigoComun.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Negocio
{
    public class DepositoServices
    {
        /*  ATRIBUTOS */
        private DepositosRepository depositosRepository = new DepositosRepository();
        private Deposito deposito = new Deposito();
        
        private List<DepositoDTO> depositosDTOs = new List<DepositoDTO>();
        private List<StockDTO> stockDTOs = new List<StockDTO>();
        
        private DepositoDTO depositoDTO = new DepositoDTO();
        private StockDTO stock = new StockDTO(); 
        
        private ArticuloServices articuloServices = new ArticuloServices();
        private StockServices stockServices= new StockServices();
        /***********
         * GETTERS 
         ***********/

        /*-----------------------GetById-------------------------------*/
        public DepositoDTO GetById(int idDeposito) 
        {
            deposito = depositosRepository.GetById(idDeposito);
            return depositoDTO.GetDepositoDTO(deposito);
        }


        /*-----------------------GetAll-------------------------------*/
        public List<DepositoDTO> GetAll() 
        {
            List<Deposito> depositos = depositosRepository.GetAll();
            return depositoDTO.GetAllDepositosDTO(depositos); 
        }



        /***********  
         *  A.B.M 
         ***********/
        /*-----------------------Add-------------------------------*/
        public DepositoDTO Add(DepositoDTO depositoDTOToAdd) 
        {
            try {

                // Validaciones
                if (depositoDTOToAdd.Capacidad != null &&
                    depositoDTOToAdd.Direccion != null &&
                    depositoDTOToAdd.Nombre != null)
                {
                    bool existe = IsNameInDB(depositoDTOToAdd);

                    if (existe == false)
                    {
                        if (depositoDTOToAdd.Capacidad != null)
                        {
                            deposito = depositoDTOToAdd.GetDeposito(depositoDTOToAdd);
                            if (depositosRepository.AddOnDB(deposito) == 1)
                            {
                                depositoDTOToAdd.HuboError = false;
                                depositoDTOToAdd.Mensaje = "Deposito Agregado con exito";
                                return depositoDTOToAdd;
                            }
                            else
                            {
                                depositoDTOToAdd.HuboError = true;
                                depositoDTOToAdd.Mensaje = "No se pudo agregar el Deposito";
                                return depositoDTOToAdd;
                            }
                        }
                        else
                        {
                            depositoDTOToAdd.HuboError = true;
                            depositoDTOToAdd.Mensaje = "Ingrese valores numericos en la Cantidad.";
                            return depositoDTOToAdd;
                        }
                    }
                    else
                    {
                        depositoDTOToAdd.HuboError = true;
                        depositoDTOToAdd.Mensaje = "El nombre del Deposito ya existe.";
                        return depositoDTOToAdd;
                    }
                }
                else 
                {
                    depositoDTOToAdd.HuboError = true;
                    depositoDTOToAdd.Mensaje = "Ingrese valores en todos los campos. Verifique valores numericos.";
                    return depositoDTOToAdd;
                }
            }
            catch(Exception ex) {
                depositoDTOToAdd.HuboError = true;
                depositoDTOToAdd.Mensaje = $"Hubo una excepción dando el alta al Deposito {ex.Message}";
                return depositoDTOToAdd;
            }
        }

        /*-----------------------Delete-------------------------------*/
        public DepositoDTO Delete(int idDepositoToDelete) 
        {
            try {
                if (this.DepositoConArticuloEnStock(idDepositoToDelete) == false)
                {
                    if (depositosRepository.DeleteOnDB(idDepositoToDelete) == 1)
                    {
                        depositoDTO.Mensaje = "Deposito Eliminado con exito";
                        return depositoDTO;
                    }
                    else
                    {
                        depositoDTO.HuboError = true;
                        depositoDTO.Mensaje = "No se pudo eliminar el Deposito";
                        return depositoDTO;
                    }
                }                
                else 
                {
                    depositoDTO.HuboError = true;
                    depositoDTO.Mensaje = "El Deposito tiene un Articulo en Stock. No se puede Eliminar.";
                    return depositoDTO;
                }
            }
            catch (Exception ex)
            {
                depositoDTO.HuboError = true;
                depositoDTO.Mensaje = $"Hubo una excepción eliminando al Deposito {ex.Message}";
                return depositoDTO;
            }
        }


        /*-----------------------Update-------------------------------*/
        public DepositoDTO Update(DepositoDTO depositoDTOToUpdate)
        {   
            try {

                // Validaciones                                
                Deposito depositoAux = depositoDTO.GetDeposito(depositoDTOToUpdate);
                bool existe = IsNameInDB(depositoDTOToUpdate);
                if(existe == true)
                {
                    depositoDTOToUpdate.HuboError = true;
                    depositoDTOToUpdate.Mensaje = "El nombre del Deposito ya existe.";
                    return depositoDTOToUpdate;
                }
                if (depositosRepository.UpdateOnDB(depositoAux) == 1 && existe == false)
                    {
                        depositoDTOToUpdate.HuboError = false;
                        depositoDTOToUpdate.Mensaje = "Deposito Modificado con exito";
                        return depositoDTOToUpdate;
                    }
                    else
                    {
                        depositoDTOToUpdate.HuboError = true;
                        depositoDTOToUpdate.Mensaje = "No se pudo Modificar el Deposito";
                        return depositoDTOToUpdate;
                    }
                
                
            }
            catch (Exception ex)
            {
                depositoDTOToUpdate.HuboError = true;
                depositoDTOToUpdate.Mensaje = $"Hubo una excepción actualizando al Deposito {ex.Message}";
                return depositoDTOToUpdate;
            }
        }


        /********************* 
         * METODOS AUXILIARES 
         *********************/
        public bool DepositoConArticuloEnStock(int idDeposito) {
            stockDTOs = stockServices.GetAll();
            foreach (StockDTO stock in stockDTOs) 
            {
                if (stock.IdDeposito == idDeposito && stock.IdArticulo!=null) { 
                    return true;
                }
            }
            return false;
        }

        #region Validaciones
        public bool IsNameInDB(DepositoDTO depositoDTO)
        {
            deposito = depositosRepository.GetByName(depositoDTO.Nombre);
            if (deposito != null)
            {
                if (depositoDTO.Nombre.ToLower().Replace(" ", "") == deposito.Nombre.ToLower().Replace(" ", "") 
                    && deposito.Id != depositoDTO.Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            //depositosDTOs = this.GetAll();
            //// Validaciones
            //foreach (DepositoDTO depo in depositosDTOs)
            //{                 
            //    if (depositoDTO.Nombre.ToLower().Replace(" ", "") == depo.Nombre.ToLower().Replace(" ", "") && depo.Id != depositoDTO.Id)
            //    {                    
            //        return true;
            //    }
            //}
            //return false;
        }    
        #endregion

    }
}
