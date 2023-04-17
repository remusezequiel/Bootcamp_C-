using CodigoComun.Datos.Repository;
using CodigoComun.Entities;

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
        private DepositosRepository Repository = new DepositosRepository();

        /*  METODOS */
        /*  GETTERS */

        /// <summary>
        /// Toma el deposito por el id pasado
        /// </summary>
        /// <param name="idDeposito"></param>
        /// <returns></returns>
        #pragma warning disable IDE0022 // Usar cuerpo del bloque para el método
        public Deposito GetDeposito(int idDeposito) => Repository.GetDepositoPorId(idDeposito);
        
        /// <summary>
        /// Toma una lista de 
        /// </summary>
        /// <returns></returns>
        #pragma warning disable IDE0022 // Usar cuerpo del bloque para el método
        public List<Deposito> GetTodosLosDepositos() => Repository.GetTodosLosDepositos();
        


        /*  A.B.M */
        /// <summary>
        ///     Utiliza las funciones del Repository
        ///     para agregar un deposito aplicando 
        ///     validaciónes.
        /// </summary>
        /// <param name="depositoToAdd"></param>
        /// <returns></returns>
        public string AddDeposito(Deposito depositoToAdd) 
        {
            // Agrego el deposito en la base
            if (this.Repository.AddDeposito(depositoToAdd) == 1)
            {
                return "Deposito Agregado con exito";    
            }
            else 
            {
                return "No se pudo agregar el Deposito";
            }
        }

        /// <summary>
        ///     Utiliza las funciones del Repository
        ///     para eliminar un deposito.  
        /// </summary>
        /// <param name="idDepositoToDelete"></param>
        /// <returns></returns>
        public string DeleteDeposito(int idDepositoToDelete) 
        {
            // Agrego el deposito en la base
            if (this.Repository.DeleteDeposito(idDepositoToDelete) == 1)
            {
                return "Deposito Eliminado con exito";
            }
            else
            {
                return "No se pudo eliminar el Deposito";
            }
        }
    }
}
