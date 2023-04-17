using CodigoComun.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Modelo
{
    public class Deposito
    {
        /****************
        *      ATRIBUTOS
        *****************/
        public int Id { get; set; }
        public decimal Capacidad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        private AccesoDatos ac = new AccesoDatos();

        /*************
         *  METODOS 
         *************/
        /// <summary>
        ///  Metodo utilizado para agregar al articulo en la base de datos
        /// </summary>
        /// <returns>
        ///     1   => si salio todo bien
        ///     -1 => si salio todo mal
        /// </returns>
        public int AgregarEnDb()
        {
            string query = $"insert into depositos (Capacidad, Nombre, Direccion)";
            query += $"values({this.Capacidad}, '{this.Nombre}', '{this.Direccion}') ";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (Exception ex)
            {
                //Log.Escribir(0, "ERROR", "Ocurrio un error en ChangeAddPartidaToProduct actualizando que guarde partida a producto " + ex.Message);
                return -1;
            }
            finally
            {
                ac.DesConectar();
            }
        }

        /// <summary>
        ///     Actualiza los datos de un deposito segun los datos pasador por parametro
        /// </summary>
        /// <param name="depositoAActualizar"></param>
        /// <returns></returns>
        public int ActualizarEnDb(Deposito depositoAActualizar)
        {
            /* 
             *        Si  SQL esta instalado en Ingles Utilizar este codigo  
             */
            //string query = $"update depositos set Capacidad = {depositoAActualizar.Capacidad}, " +
            //    $"Nombre='{depositoAActualizar.Nombre}', " +
            //    $"Direccion = '{depositoAActualizar.Direccion}' " +
            //    $"where id = {depositoAActualizar.Id}";

            string CapacidadAux = depositoAActualizar.Capacidad.ToString();
            CapacidadAux = CapacidadAux.Replace(",", ".");

            string query = $"update depositos set Capacidad = {CapacidadAux}, " +
                $"Nombre='{depositoAActualizar.Nombre}', " +
                $"Direccion = '{depositoAActualizar.Direccion}' " +
                $"where id = {depositoAActualizar.Id}";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                ac.DesConectar();
            }
        }

        /// <summary>
        ///     Elimina los datos de un deposito en la base de datos
        /// </summary>
        /// <param name="idDepositoEliminar"></param>
        /// <returns></returns>
        public int EliminarEnDb(int idDepositoEliminar)
        {
            string query = $"delete depositos where id={idDepositoEliminar}";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                return r;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                ac.DesConectar();
            }
        }

        /// <summary>
        ///     Toma un articulo de la base de datos
        /// </summary>
        /// <param name="depositoId"></param>
        /// <returns>
        ///     Si sale todo bien => el deposito correspondiente
        ///     Si sale todo mal =>  Excepcion
        /// </returns>
        public Deposito GetDepositoPorId(int depositoId) 
        {
            try
            {
                string select = $"select * from Depositos where id = {depositoId}";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }
                Deposito depositoADevolverConDatosDeLaBaseDeDatos = new Deposito();
                foreach (DataRow dr in dt.Rows)
                {
                    depositoADevolverConDatosDeLaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    depositoADevolverConDatosDeLaBaseDeDatos.Capacidad = Convert.ToDecimal(dr["Capacidad"]);
                    depositoADevolverConDatosDeLaBaseDeDatos.Nombre = dr["Nombre"].ToString();
                    depositoADevolverConDatosDeLaBaseDeDatos.Direccion = dr["Direccion"].ToString();
                }
                return depositoADevolverConDatosDeLaBaseDeDatos;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally 
            {
                ac.DesConectar();
            }
        }

        /// <summary>
        ///     Toma una lista de articulos de la base de datos
        /// </summary>
        /// <returns>
        ///     Si sale todo bien => lista de depositos correspondiente
        ///     Si sale todo mal =>  Excepcion
        /// </returns>
        public List<Deposito> GetTodosLosDepositos() 
        {
            try 
            {
                string select = $"select * from Depositos";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }

                List<Deposito> depositosADevovlerConDatosDelaBaseDeDatos = new List<Deposito>();
                foreach (DataRow dr in dt.Rows)
                {
                    Deposito DepositoAux = new Deposito();
                    DepositoAux.Id = Convert.ToInt32(dr["Id"]);
                    DepositoAux.Capacidad = Convert.ToDecimal(dr["Capacidad"]);
                    DepositoAux.Nombre = dr["Nombre"].ToString();
                    DepositoAux.Direccion = dr["Direccion"].ToString();

                    depositosADevovlerConDatosDelaBaseDeDatos.Add(DepositoAux);
                }
                return depositosADevovlerConDatosDelaBaseDeDatos;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                ac.DesConectar();
            }
        }


    }
}
