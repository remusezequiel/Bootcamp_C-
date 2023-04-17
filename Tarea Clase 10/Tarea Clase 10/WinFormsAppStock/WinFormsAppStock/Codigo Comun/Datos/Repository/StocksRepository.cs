using CodigoComun.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Datos.Repository
{
    public class StocksRepository
    {
        /*  ATRIBUTOS */
        private StockAppContext db = new StockAppContext();

        /*  METODOS */

        /*  GETTERS */
        /// <summary>
        ///     Toma los todos los stocks de la DB
        /// </summary>
        /// <returns>La lista de Stock</returns>
        public List<Stock> GetTodosLosStocks()
        {
            List<Stock> stocksADevolver = new List<Stock>();
            stocksADevolver = this.db.Stocks.ToList();

            return stocksADevolver;
        }

        /// <summary>
        ///     Toma el stock pasado por id
        /// </summary>
        /// <param name="idStock"></param>
        /// <returns></returns>
        public Stock GetStockPorId(int idStock)
        {
#pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            Stock stockADevolver = this.db.Stocks.Where(
                p => p.Id == idStock).FirstOrDefault();

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return stockADevolver;
        }

        /*  A.B.M */

        /// <summary>
        ///     Utiliza Entity Framework para 
        ///     guardar el stock en la base de datos
        /// </summary>
        /// <param name="stockToAdd"></param>
        /// <returns></returns>
        public int AddStock(Stock stockToAdd)
        {
            this.db.Stocks.Add(stockToAdd);
            int r = db.SaveChanges();
            return r;
        }

        /// <summary>
        ///     Utiliza Entity Framework para 
        ///     eliminar el Stock de la base de datos
        /// </summary>
        /// <param name="idStockToDelete"></param>
        /// <returns></returns>
        public int DeleteStock(int idStockToDelete)
        {
            // Obtengo al deposito
            Stock stockToDelete = this.GetStockPorId(idStockToDelete);
            // lo borro de la DB
            this.db.Stocks.Remove(stockToDelete);
            
            return this.db.SaveChanges(); ;
        }

        /// <summary>
        ///     Utiliza Entity Framework para
        ///     modificar el stock pasado
        /// </summary>
        /// <param name="stockToUpdate"></param>
        /// <returns></returns>
        public int UpdateStock(Stock stockToUpdate)
        {
            db.Entry(stockToUpdate).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
