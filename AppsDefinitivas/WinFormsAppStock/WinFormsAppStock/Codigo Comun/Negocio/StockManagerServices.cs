using Codigo_Comun.Entities.DTO;
using Codigo_Comun.Negocio;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Negocio
{
    public class StockManagerServices
    {
        #region Atributos
        private StockServices stockServices = new StockServices();
        private ArticuloServices articuloServices = new ArticuloServices();
        private ArticuloDTO articuloDTO = new ArticuloDTO();
        private StockDTO stockDTO = new StockDTO();
        private List<StockDTO> stockDTOs = new List<StockDTO>();
        #endregion


        #region Metodos: Ingresar/Egresar
        /// <summary>
        ///     Realiza la creacion o modificacion de un stock existente.
        ///     Si el codigo de articulo ingresado no existe, entonces no creara el stock
        ///     La modificacion realizada sera una suma de cantidades entre existente y 
        ///     deseada a agregar
        /// </summary>
        /// <param name="stockToIncome"></param>
        /// <returns></returns>
        public StockManager IncomeOrAdd(StockManager stockToIncome)
        {
            articuloDTO.Codigo = stockToIncome.CodigoArticulo;
            // Si no me da cero, me devuelve el Id del articulo que tiene el codigo.
            ArticuloDTO isCodeArticulo = articuloServices.IsCodeInDBDevuelveIdOCero(articuloDTO);

            if (isCodeArticulo.Id == 0)
            {
                stockToIncome.HuboError = true;
                stockToIncome.Mensaje = "El Codigo del Articulo no existe.";
                return stockToIncome;
            }
            else
            {
                stockDTO.IdArticulo = isCodeArticulo.Id;
                stockDTO.IdDeposito = stockToIncome.IdDeposito;
                stockDTO = stockServices.IsStockInDBdevuelveIdOCero(stockDTO);
                stockDTO.Cantidad = stockDTO.Cantidad + stockToIncome.Cantidad;

                if (stockDTO.Id != 0)
                {
                    stockDTO = stockServices.Update(stockDTO);
                    stockToIncome.Mensaje = stockDTO.Mensaje + $"\nLa Cantidad actual es: {stockDTO.Cantidad} ";
                    stockToIncome.HuboError = stockDTO.HuboError;
                    return stockToIncome;
                }
                else
                {
                    if (stockToIncome.Cantidad < isCodeArticulo.MinimoStock)
                    {
                        stockDTO.Cantidad = isCodeArticulo.MinimoStock;
                        stockDTO = stockServices.Add(stockDTO);
                        stockToIncome.Mensaje = stockDTO.Mensaje +
                                                $"\nEl nuevo stock al ser creado por primera lo hara un minimo de {stockDTO.Cantidad}";
                        stockToIncome.HuboError = stockDTO.HuboError;
                        return stockToIncome;
                    }
                    else {
                        stockDTO.Cantidad = stockToIncome.Cantidad;
                        stockDTO = stockServices.Add(stockDTO);
                        stockToIncome.Mensaje = stockDTO.Mensaje + $"\nSe creo con un Stock de {stockToIncome.Cantidad}";
                        stockToIncome.HuboError = stockDTO.HuboError;
                        return stockToIncome;
                    }                
                }

            }

        }

        /* DISCHARGE */
        public StockManager Discharge(StockManager stockToDischarge)
        {
            articuloDTO.Codigo = stockToDischarge.CodigoArticulo;
            // Si no me da cero, me devuelve el Id del articulo que tiene el codigo.
            ArticuloDTO isCodeArticulo = articuloServices.IsCodeInDBDevuelveIdOCero(articuloDTO);

            if (isCodeArticulo.Id == 0)
            {
                stockToDischarge.HuboError = true;
                stockToDischarge.Mensaje = "El Codigo del Articulo no existe.";
                return stockToDischarge;
            }
            else
            {
                stockDTO.IdArticulo = isCodeArticulo.Id;
                stockDTO.IdDeposito = stockToDischarge.IdDeposito;
                stockDTO = stockServices.IsStockInDBdevuelveIdOCero(stockDTO);
                if (stockDTO.Id != 0 && stockDTO.Cantidad >= stockToDischarge.Cantidad)
                {
                    stockDTO.HuboError = false;
                    stockDTO.Cantidad = stockDTO.Cantidad - stockToDischarge.Cantidad;
                    stockDTO = stockServices.Update(stockDTO);
                    stockToDischarge.Mensaje = stockDTO.Mensaje + $"\nLa Cantidad actual es: {stockDTO.Cantidad} ";
                    stockToDischarge.HuboError = stockDTO.HuboError;
                    return stockToDischarge;
                }
                else if (stockDTO.Id != 0 && stockDTO.Cantidad < stockToDischarge.Cantidad)
                {
                    stockToDischarge.Mensaje = $"La cantidad a Egresar supera a la cantidad en Stock, la cual es {stockDTO.Cantidad}.";
                    stockToDischarge.HuboError = true;
                    return stockToDischarge;
                }
                else 
                {
                    stockToDischarge.Mensaje = $"No existe la relacion Articulo-Deposito";
                    stockToDischarge.HuboError = true;
                    return stockToDischarge;
                }
            }
        }
        #endregion
    }
}