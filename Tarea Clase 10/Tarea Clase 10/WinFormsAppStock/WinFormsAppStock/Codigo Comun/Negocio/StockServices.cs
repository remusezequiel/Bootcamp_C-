using CodigoComun.Datos.Repository;
using CodigoComun.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_Comun.Negocio
{
    public class StockServices
    {

        /*  ATRIBUTOS */
        private StocksRepository Repository = new StocksRepository();

        /*  METODOS */
        /*  GETTERS */

        /// <summary>
        /// Toma el Stock por el id pasado
        /// </summary>
        /// <param name="idStock"></param>
        /// <returns></returns>
#pragma warning disable IDE0022 // Usar cuerpo del bloque para el método
        public Stock GetDeposito(int idStock) => Repository.GetStockPorId(idStock);

        /// <summary>
        /// Toma una lista de Stock de la DB
        /// </summary>
        /// <returns></returns>
#pragma warning disable IDE0022 // Usar cuerpo del bloque para el método
        public List<Stock> GetTodosLosStocks() => Repository.GetTodosLosStocks();



        /*  A.B.M */
        /// <summary>
        ///     Utiliza las funciones del Repository
        ///     para agregar un deposito aplicando 
        ///     validaciónes.
        /// </summary>
        /// <param name="stockToAdd"></param>
        /// <returns></returns>
        public string AddStock(Stock stockToAdd)
        {            
            if (this.Repository.AddStock(stockToAdd) == 1)
            {
                return "Stock Agregado con exito";
            }
            else
            {
                return "No se pudo agregar el Stock";
            }
        }

        /// <summary>
        ///     Utiliza las funciones del Repository
        ///     para eliminar un deposito.  
        /// </summary>
        /// <param name="idStockToDelete"></param>
        /// <returns></returns>
        public string DeleteStock(int idStockToDelete)
        {
            // Agrego el deposito en la base
            if (this.Repository.DeleteStock(idStockToDelete) == 1)
            {
                return "Stock Eliminado con exito";
            }
            else
            {
                return "No se pudo eliminar el Stock";
            }
        }

        /// <summary>
        ///     Utiliza las funciones del Repository
        ///     para actualizar un deposito aplicando 
        ///     validaciónes.
        /// </summary>
        /// <param name="stockToAdd"></param>
        /// <returns></returns>
        public string UpdateStock(Stock stockToUpdate)
        {
            if (this.Repository.UpdateStock(stockToUpdate) == 1)
            {
                return "Stock Modificado con exito";
            }
            else
            {
                return "No se pudo Modificar el Stock";
            }
        }
    }
}
