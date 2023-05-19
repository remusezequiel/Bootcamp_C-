using CodigoComun.Datos.Repository;
using CodigoComun.Entities;
using CodigoComun.Entities.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodigoComun.Modelo.DTO;
using CodigoComun.Negocio;

namespace Codigo_Comun.Negocio
{
    public class StockServices
    {
        /*  ATRIBUTOS */
        private StocksRepository stockRepository = new StocksRepository();
        public StockDTO stockDTO = new StockDTO();
        
        public Stock stock = new Stock();
        public List<StockDTO> stockDTOs = new List<StockDTO>();
      
        
        /*  METODOS */
        /*  GETTERS */

        /*-----------------------GetById-------------------------------*/
        public StockDTO GetById(int idStock)
        {
            stock = stockRepository.GetById(idStock);
            return stockDTO.GetStockDTO(stock);
        }


        /*-----------------------GetAll-------------------------------*/
        public List<StockDTO> GetAll()
        {
            List<Stock> stock = stockRepository.GetAll();
            return stockDTO.GetAllStocksDTO(stock);
        }



        /***********  
         *  A.B.M 
         ***********/
        /*-----------------------Add-------------------------------*/
        public StockDTO Add(StockDTO stockDTOToAdd)
        {
            try
            {

                if (IsStockInDB(stockDTOToAdd) == false)
                {

                    stock = stockDTOToAdd.GetStock(stockDTOToAdd);

                    if (stockRepository.AddOnDB(stock) == 1)
                    {
                        stockDTOToAdd.HuboError = false;
                        stockDTOToAdd.Mensaje = "Stock Agregado con exito";
                        return stockDTOToAdd;
                    }
                    else
                    {
                        stockDTOToAdd.HuboError = true;
                        stockDTOToAdd.Mensaje = "No se pudo agregar el Stock";
                        return stockDTOToAdd;
                    }
                }
                else {
                    stockDTOToAdd.HuboError = true;
                    stockDTOToAdd.Mensaje = "\tNo se puede repetir el alta de un Stock.\n Ya existe esta relación Articulo-Deposito";
                    return stockDTOToAdd;
                }
            }
            catch (Exception ex)
            {
                stockDTOToAdd.HuboError = true;
                stockDTOToAdd.Mensaje = $"Hubo una excepción dando el alta al Deposito {ex.Message}";
                return stockDTOToAdd;
            }
        }

        /*-----------------------Delete-------------------------------*/
        public StockDTO Delete(int idStockToDelete)
        {
            try
            {
                if (stockRepository.DeleteOnDB(idStockToDelete) == 1)
                {
                    stockDTO.Mensaje = "Stock Eliminado con exito";
                    return stockDTO;
                }
                else
                {
                    stockDTO.HuboError = true;
                    stockDTO.Mensaje = "No se pudo eliminar el Stock";
                    return stockDTO;
                }
            }
            catch (Exception ex)
            {
                stockDTO.HuboError = true;
                stockDTO.Mensaje = $"Hubo una excepción eliminando al Stock {ex.Message}";
                return stockDTO;
            }
        }


        /*-----------------------Update-------------------------------*/
        public StockDTO Update(StockDTO stockDTOToUpdate)
        {
            try
            {
                if (IsStockInDB(stockDTOToUpdate) == false)
                {
                    stock = stockDTO.GetStock(stockDTOToUpdate);
                    if (stockRepository.UpdateOnDB(stock) == 1)
                    {
                        stockDTOToUpdate.HuboError = false;
                        stockDTOToUpdate.Mensaje = "Stock Modificado con exito";
                        return stockDTOToUpdate;
                    }
                    else
                    {
                        stockDTOToUpdate.HuboError = true;
                        stockDTOToUpdate.Mensaje = "No se pudo Modificar el Stock";
                        return stockDTOToUpdate;
                    }
                }
                else
                {
                    stockDTOToUpdate.HuboError = true;
                    stockDTOToUpdate.Mensaje = "\tNo se puede repetir el alta de un Stock.\n Ya existe esta relación Articulo-Deposito";
                    return stockDTOToUpdate;
                }
            }
            catch (Exception ex)
            {
                stockDTOToUpdate.HuboError = true;
                stockDTOToUpdate.Mensaje = $"Hubo una excepción actualizando al Stock {ex.Message}";
                return stockDTOToUpdate;
            }
        }

        #region IngresoEgreso
        public StockDTO IncomeOrAdd(StockDTO stockDTOToIncome) 
        {
            stockDTOs = this.GetAll();
            foreach (StockDTO s in stockDTOs) {
                if (stockDTOToIncome.IdArticulo == s.IdArticulo &&
                    stockDTOToIncome.IdDeposito == s.IdDeposito)
                {
                    stockDTOToIncome.Id = s.Id;
                    stockDTOToIncome.Cantidad = s.Cantidad + stockDTOToIncome.Cantidad;
                    stockDTOToIncome.Origen = "Ingresar";
                    break;
                }
                else 
                {
                    stockDTOToIncome.Id = 0;
                    stockDTOToIncome.Origen = "Crear";
                }
            }

            if (stockDTOToIncome.Origen == "Ingresar")
            {
                return this.Update(stockDTOToIncome);
            }
            else 
            {
                return this.Add(stockDTOToIncome);                                
            }

        }


        public StockDTO Discharge(StockDTO stockDTOToDischarge) 
        {
            stockDTOs = this.GetAll();
            foreach (StockDTO s in stockDTOs)
            {
                if (stockDTOToDischarge.IdArticulo == s.IdArticulo &&
                    stockDTOToDischarge.IdDeposito == s.IdDeposito)
                {
                    if (s.Cantidad > stockDTOToDischarge.Cantidad) 
                    {
                        stockDTOToDischarge.Id = s.Id;
                        stockDTOToDischarge.Cantidad = s.Cantidad - stockDTOToDischarge.Cantidad;
                        stockDTOToDischarge.Origen = "Egresar";                    
                        
                    }
                    break;
                }
                else
                {
                    stockDTOToDischarge.Origen = "NoEgresar";
                    stockDTOToDischarge.HuboError = true;
                    stockDTOToDischarge.Mensaje = "No se puede hacer el Egreso.\n La cantidad que se quiere egresar es mayor a la existente";
                }
            }
            if (stockDTOToDischarge.Origen == "Egresar")
            {
                return this.Update(stockDTOToDischarge);
            }
            else 
            {
                return stockDTOToDischarge;
            }
        }

        #endregion


        #region Validaciones

        /// <summary>
        /// Devuelve true si el stock esta el la base de datos 
        /// y el id del stock pasado por id es distinto al coincidente.
        /// </summary>
        /// <param name="stockDTO"></param>
        /// <returns></returns>
        public bool IsStockInDB(StockDTO stockDTO)
        {
            int id = stockDTO.Id;
            int idArticulo = (int)stockDTO.IdArticulo;
            int idDeposito = (int)stockDTO.IdDeposito;

            if (stockRepository.GetByArticuloAndDeposito(idArticulo, idDeposito) != null)
            {
                stock = stockRepository.GetByArticuloAndDeposito(idArticulo, idDeposito);
                if (id != stock.Id)
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
        }

        /// <summary>
        ///     Busca si existe el stock en la base de datos
        ///     segun si 
        /// </summary>
        /// <param name="stockDTO"></param>
        /// <returns></returns>
        public StockDTO IsStockInDBdevuelveIdOCero(StockDTO stockDTO)
        {
            int id = stockDTO.Id;
            int idArticulo = (int)stockDTO.IdArticulo;
            int idDeposito = (int)stockDTO.IdDeposito;

            if (stockRepository.GetByArticuloAndDeposito(idArticulo, idDeposito) != null)
            {
                stock = stockRepository.GetByArticuloAndDeposito(idArticulo, idDeposito);
                if (id != stock.Id)
                {
                    return stockDTO.GetStockDTO(stock);
                }
                else
                {
                    stockDTO.Id = 0;
                    return stockDTO;
                }
            }
            else {
                stockDTO.Id = 0;
                return stockDTO;
            }
       }
        
        #endregion

    }
}

