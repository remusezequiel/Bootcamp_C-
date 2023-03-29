using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppAlumnos.Datos;

namespace WinFormsAppAlumnos.Clases
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public decimal Sueldo { get; set; }
        public DateTime FechaNAcimiento { get; set; }

        private AccesoDatos ac = new AccesoDatos();
       
        
        /// <summary>
        ///     Agrega en la base de datos los datos
        ///     pasados correspondientes a un profesor. 
        /// </summary>
        /// <returns>
        ///     -1 -> Algo salio MAL
        ///     
        /// </returns>
        public int AgregarEnDb()
        {
            Console.WriteLine("Agregando en la DB\n\t\t0%");
            string query = $"insert into profesores (Nombre, Apellido, Documento, Telefono, Mail, Sueldo, FechaNacimiento)";
            Console.WriteLine("..................\t\t10%");
            query += $"values('{this.Nombre}', '{this.Apellido}', '{this.Documento}', '{this.Telefono}', " +
                $" '{this.Mail}', {this.Sueldo}, '{this.FechaNAcimiento.ToString("yyyyMMdd")}') ";
            Console.WriteLine("..................\t\t30%");
            try
            {
                Console.WriteLine("..................\t\t40%");
                SqlCommand command = new SqlCommand(query);
                Console.WriteLine("..................\t\t60%");
                int r = ac.ejecQueryDevuelveInt(command);
                Console.WriteLine("..................\t\t80%");
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
        ///     Funcion que actualiza los datos de un profesor en la base de datos
        /// </summary>
        /// <param name="profesorAActualizar"></param>
        /// <returns></returns>
        public int ActualizarEnDb(Profesor profesorAActualizar)
        {
            string query = $"update profesores set Nombre = '{profesorAActualizar.Nombre}', " +
                $"Apellido='{profesorAActualizar.Apellido}', " +
                $"Documento='{profesorAActualizar.Documento}', " +
                $"Telefono = '{profesorAActualizar.Telefono}', " +
                $"Mail = '{profesorAActualizar.Mail}', " +
                $"Sueldo = {profesorAActualizar.Sueldo}, " +
                $"FechaNacimiento = '{profesorAActualizar.FechaNAcimiento.ToString("yyyyMMdd")}' " +
                $"where id = {profesorAActualizar.Id}";
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
        ///     Elimina los datos de un profesor en la base de datos
        /// </summary>
        /// <param name="idProfesorEliminar">
        ///     Id del profesor a eliminar
        /// </param>
        /// <returns>
        ///     1   => si salio todo bien
        /// -1 => si salio todo mal
        /// </returns>
        public int EliminarEnDb(int idProfesorEliminar)
        {
            Console.WriteLine("Buscando al profe a borrar...");
            string query = $"delete profesores where id={idProfesorEliminar}";
            try
            {
                SqlCommand command = new SqlCommand(query);
                int r = ac.ejecQueryDevuelveInt(command);
                Console.WriteLine("Profesor Eliminado");
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
        ///  Hace un Get de los datos del profesor segun el id Correspondiente
        /// </summary>
        /// <param name="profesorId"></param>
        /// <returns>
        ///     Si sale bien, devuelve al profesor 
        ///     Sino, una exepcion
        /// </returns>
        public Profesor GetProfesorPorId(int profesorId)
        {
            try
            {
                string select = $"select * from Profesores where id={profesorId}";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);
                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }
                Profesor profesorADevovlerConDatosDelaBaseDeDatos = new Profesor();
                foreach (DataRow dr in dt.Rows)
                {
                    profesorADevovlerConDatosDelaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    profesorADevovlerConDatosDelaBaseDeDatos.Nombre = dr["Nombre"].ToString();
                    profesorADevovlerConDatosDelaBaseDeDatos.Apellido = dr["Apellido"].ToString();
                    profesorADevovlerConDatosDelaBaseDeDatos.Documento = dr["Documento"].ToString();
                    profesorADevovlerConDatosDelaBaseDeDatos.Telefono = dr["Telefono"].ToString();
                    profesorADevovlerConDatosDelaBaseDeDatos.Mail = dr["Mail"].ToString();
                    profesorADevovlerConDatosDelaBaseDeDatos.Sueldo = Convert.ToDecimal(dr["Sueldo"]);
                    profesorADevovlerConDatosDelaBaseDeDatos.FechaNAcimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                }
                return profesorADevovlerConDatosDelaBaseDeDatos;
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
        ///     Toma a todos los profesores existentes 
        ///     en la base de datos
        /// </summary>
        /// <returns>
        ///     Si sale Bien -> La lista de profesores 
        ///     Si sale mal   -> null
        /// </returns>
        public List<Profesor> GetTodosLosProfesores()
        {
            try
            {
                string select = $"select * from Profesores ";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }

                List<Profesor> profesorADevovlerConDatosDelaBaseDeDatos = new List<Profesor>();
                foreach (DataRow dr in dt.Rows)
                {
                    Profesor ProfesorAuxiliar = new Profesor();
                    ProfesorAuxiliar.Id = Convert.ToInt32(dr["Id"]);
                    ProfesorAuxiliar.Nombre = dr["Nombre"].ToString();
                    ProfesorAuxiliar.Apellido = dr["Apellido"].ToString();
                    ProfesorAuxiliar.Documento = dr["Documento"].ToString();
                    ProfesorAuxiliar.Telefono = dr["Telefono"].ToString();
                    ProfesorAuxiliar.Mail = dr["Mail"].ToString();
                    ProfesorAuxiliar.Sueldo = Convert.ToDecimal(dr["Sueldo"]);
                    ProfesorAuxiliar.FechaNAcimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                    //agrego a la lista
                    profesorADevovlerConDatosDelaBaseDeDatos.Add(ProfesorAuxiliar);
                }
                return profesorADevovlerConDatosDelaBaseDeDatos;
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
