using CodigoComun.Datos;
using CodigoComun.Datos.Repository;
using CodigoComun.Entities;
using CodigoComun.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Modelo
{
    public class Stock
    {

        /****************
        *      ATRIBUTOS
        *****************/
        public int Id { get; set; }
        public Articulo ArticuloGuardado { get; set; }
        public CodigoComun.Entities.Deposito DepositoDondeEstaGuardado { get; set; }
        public decimal Cantidad { get; set; }
        private AccesoDatos ac = new AccesoDatos();


        /****************
        *      METODOS
        *****************/

        /// <summary>
        ///  Metodo utilizado para agregar al articulo en la base de datos
        /// </summary>
        /// <returns>
        ///     1   => si salio todo bien
        ///     -1 => si salio todo mal
        /// </returns>
        public int AgregarEnDb()
        {
            string query = $"insert into stocks (IdArticulo, IdDeposito, Cantidad)";
            query += $"values({this.ArticuloGuardado.Id}, {this.DepositoDondeEstaGuardado.Id}, {this.Cantidad})";
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
        ///     Actualiza los datos de un articulo segun los datos pasador por parametro
        /// </summary>
        /// <param name="stockAActualizar"></param>
        /// <returns></returns>
        public int ActualizarEnDb(Stock stockAActualizar)
        {
            /* 
             *        Si  SQL esta instalado en Ingles Utilizar este codigo  
             */
            //string query = $"update stocks set IdArticulo = {stockAActualizar.ArticuloGuardado.Id}, " +
            //    $"IdDeposito={stockAActualizar.DepositoDondeEstaGuardado.Id}, " +
            //    $"Cantidad={stockAActualizar.Cantidad} " +
            //     $"where id = {stockAActualizar.Id}";

            string CantidadAux = stockAActualizar.Cantidad.ToString();
            CantidadAux = CantidadAux.Replace(",", ".");
            string query = $"update stocks set IdArticulo = {stockAActualizar.ArticuloGuardado.Id}, " +
                $"IdDeposito={stockAActualizar.DepositoDondeEstaGuardado.Id}, " +
                $"Cantidad={CantidadAux} " +
                 $"where id = {stockAActualizar.Id}";
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
        ///     Elimina los datos de un articulo en la base de datos
        /// </summary>
        /// <param name="idStockEliminar"></param>
        /// <returns></returns>
        public int EliminarEnDb(int idStockEliminar)
        {
            string query = $"delete stocks where id={idStockEliminar}";
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
        ///     Toma de la base de datos los 
        ///     elementos del Stock pasado por id
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public Stock GetStockPorId(int stockId)
        {
            try
            {
                string select = $"select * from stocks where id={stockId}";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);


                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }

                Stock stockADevovlerConDatosDelaBaseDeDatos = new Stock();
                foreach (DataRow dr in dt.Rows)
                {
                    stockADevovlerConDatosDelaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    stockADevovlerConDatosDelaBaseDeDatos.Cantidad = Convert.ToDecimal(dr["Cantidad"]);

                    ArticulosRepository articuloAux = new ArticulosRepository();
                    //Articulo articuloAux = new Articulo();
                    Articulo ArticuloStock = new Articulo();
                    CodigoComun.Entities.Deposito depositoAux = new CodigoComun.Entities.Deposito();
                    DepositoServices depositoServices = new DepositoServices();

                    int idArticuloDelStock = Convert.ToInt32(dr["IdArticulo"]);
                    int idDepositoDelStock = Convert.ToInt32(dr["IdDeposito"]);

                    ArticuloStock = articuloAux.GetArticuloById(idArticuloDelStock);
                    depositoAux = depositoServices.GetDeposito(idDepositoDelStock);
                    stockADevovlerConDatosDelaBaseDeDatos.ArticuloGuardado = ArticuloStock;
                    stockADevovlerConDatosDelaBaseDeDatos.DepositoDondeEstaGuardado = depositoAux;
                }
                return stockADevovlerConDatosDelaBaseDeDatos;
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
        ///     Toma una lista con todos los Stocks
        ///     de la base de datos
        /// </summary>
        /// <returns></returns>
        public List<Stock> GetTodosLosStocks()
        {
            try
            {
                string select = $"select * from stocks";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }

                List<Stock> stocksADevovlerConDatosDelaBaseDeDatos = new List<Stock>();
                foreach (DataRow dr in dt.Rows)
                {
                    Stock stockAux = new Stock();
                    ArticulosRepository articuloAux = new ArticulosRepository();
                    //Articulo articuloAux = new Articulo();
                    Articulo ArticuloStock = new Articulo();
                    CodigoComun.Entities.Deposito depositoAux = new CodigoComun.Entities.Deposito();
                    DepositoServices DepositoStock = new DepositoServices();
                    //Deposito DepositoStock = new Deposito();



                    int idArticuloDelStock = Convert.ToInt32(dr["IdArticulo"]);
                    int idDepositoDelStock = Convert.ToInt32(dr["IdDeposito"]);

                    ArticuloStock = articuloAux.GetArticuloById(idArticuloDelStock);
                    depositoAux = DepositoStock.GetDeposito(idDepositoDelStock);

                    stockAux.Id = Convert.ToInt32(dr["Id"]);
                    stockAux.Cantidad = Convert.ToDecimal(dr["Cantidad"]);
                    stockAux.ArticuloGuardado = ArticuloStock;
                    stockAux.DepositoDondeEstaGuardado = depositoAux;

                    //agrego a la lista
                    stocksADevovlerConDatosDelaBaseDeDatos.Add(stockAux);
                }

                return stocksADevovlerConDatosDelaBaseDeDatos;
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
