using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodigoComun.Modelo;

namespace CodigoComun.Datos.Repository
{
    public class ArticulosRepository
    {
        /****************
        *      ATRIBUTOS
        *****************/
        private AccesoDatos ac = new AccesoDatos();
        /****************
        *      METODOS
        *****************/
        public Articulo GetArticuloById(int idArticulo) 
        {
            try
            {
                string select = $"select * from Articulos where id={idArticulo}";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }

                Articulo articuloADevovlerConDatosDelaBaseDeDatos = new Articulo();
                foreach (DataRow dr in dt.Rows)
                {
                    articuloADevovlerConDatosDelaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    articuloADevovlerConDatosDelaBaseDeDatos.Nombre = dr["Nombre"].ToString();
                    articuloADevovlerConDatosDelaBaseDeDatos.Marca = dr["Marca"].ToString();
                    articuloADevovlerConDatosDelaBaseDeDatos.MinimoStock = Convert.ToDecimal(dr["MinimoStock"]);
                    articuloADevovlerConDatosDelaBaseDeDatos.Proveedor = dr["Proveedor"].ToString();
                    articuloADevovlerConDatosDelaBaseDeDatos.Precio = Convert.ToDecimal(dr["Precio"]);
                    articuloADevovlerConDatosDelaBaseDeDatos.Codigo = dr["Codigo"].ToString();
                }

                return articuloADevovlerConDatosDelaBaseDeDatos;
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

        public List<Articulo> GetAllArticulosById() 
        {
            try
            {
                string select = $"select * from Articulos ";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }

                List<Articulo> articulosADevovlerConDatosDelaBaseDeDatos = new List<Articulo>();
                foreach (DataRow dr in dt.Rows)
                {
                    Articulo ArticuloAux = new Articulo();
                    ArticuloAux.Id = Convert.ToInt32(dr["Id"]);
                    ArticuloAux.Nombre = dr["Nombre"].ToString();
                    ArticuloAux.Marca = dr["Marca"].ToString();
                    ArticuloAux.MinimoStock = Convert.ToDecimal(dr["MinimoStock"]);
                    ArticuloAux.Proveedor = dr["Proveedor"].ToString();
                    ArticuloAux.Precio = Convert.ToDecimal(dr["Precio"]);
                    ArticuloAux.Codigo = dr["Codigo"].ToString();
                    //agrego a la lista
                    articulosADevovlerConDatosDelaBaseDeDatos.Add(ArticuloAux);
                }

                return articulosADevovlerConDatosDelaBaseDeDatos;
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

        public int AddArticuloDB(Articulo articuloToAdd) 
        {
            string query = $"insert into Articulos (Nombre, Marca, MinimoStock, Proveedor, Precio, Codigo)";
            query += $"values('{articuloToAdd.Nombre}'," +
                $"'{articuloToAdd.Marca}'," +
               $" {articuloToAdd.MinimoStock}, " + 
               $" '{articuloToAdd.Proveedor}'," + 
               $" {articuloToAdd.Precio}," +
               $" '{articuloToAdd.Codigo}')";
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

        public int DeleteArticluloOnDB(int idArticuloToDelete) 
        {
            string query = $"delete articulos where id={idArticuloToDelete}";
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

        public int ModifyArticuloOnDB(Articulo articuloToModify) 
        {
            string MinStockAux = articuloToModify.MinimoStock.ToString();
            string PrecioAux = articuloToModify.Precio.ToString();

            MinStockAux = MinStockAux.Replace(",", ".");
            PrecioAux = PrecioAux.Replace(",", ".");

            string query = $"update articulos set Nombre='{articuloToModify.Nombre}', " +
                $"Marca='{articuloToModify.Marca}', " +
                $"MinimoStock={MinStockAux}, " +
                $"Proveedor='{articuloToModify.Proveedor} '," +
                $"Precio={PrecioAux}," +
                $"Codigo='{articuloToModify.Codigo}'" +
                $"where id = {articuloToModify.Id}";
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
    }
}
