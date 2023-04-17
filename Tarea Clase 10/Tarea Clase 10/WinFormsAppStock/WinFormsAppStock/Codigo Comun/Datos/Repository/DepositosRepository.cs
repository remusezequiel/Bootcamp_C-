using CodigoComun.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Datos.Repository
{
    public class DepositosRepository
    {   
        /*  ATRIBUTOS */
        private StockAppContext db = new StockAppContext();

        /*  METODOS */

        /*  GETTERS */

        /// <summary>
        ///     Toma todos los depositos ubicados en la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Deposito> GetTodosLosDepositos() 
        {
            List<Deposito> depositosADevolver = new List<Deposito>();
            depositosADevolver = this.db.Depositos.ToList();
            
            return depositosADevolver;
        }

        /// <summary>
        ///     Toma el deposito pasado por id
        /// </summary>
        /// <param name="idDeposito"></param>
        /// <returns></returns>
        public Deposito GetDepositoPorId(int idDeposito)
        {
            #pragma warning disable CS8600 // Se va a convertir un literal nulo o un posible valor nulo en un tipo que no acepta valores NULL
            Deposito depositoADevolver = this.db.Depositos.Where(
                p => p.Id == idDeposito).FirstOrDefault();

            #pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return depositoADevolver;
        }

        /*  A.B.M */

        /// <summary>
        ///     Utiliza Entity Framework para 
        ///     guardar el deposito en la base de datos
        /// </summary>
        /// <param name="depositoToAdd"></param>
        /// <returns></returns>
        public int AddDeposito(Deposito depositoToAdd)   
        {
            this.db.Depositos.Add(depositoToAdd);
            int r = db.SaveChanges();
            return r;
        }

        /// <summary>
        ///     Utiliza Entity Framework para 
        ///     eliminar el deposito de la base de datos
        /// </summary>
        /// <param name="idDepositoToDelete"></param>
        /// <returns></returns>
        public int DeleteDeposito(int idDepositoToDelete) 
        { 
            // Obtengo al deposito
            Deposito depostitoToDelete = this.GetDepositoPorId(idDepositoToDelete);
            // lo borro de la DB
            this.db.Depositos.Remove(depostitoToDelete);
            // Guardo los Cambios
            int r = this.db.SaveChanges();

            return r;
        }

        /// <summary>
        ///     Utiliza Entity Framework para
        ///     modificar el deposito pasado
        /// </summary>
        /// <param name="depositoToUpdate"></param>
        /// <returns></returns>
        public int UpdateDeposito(Deposito depositoToUpdate) 
        {            
            db.Entry(depositoToUpdate).State = EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
