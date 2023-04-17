using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppAlumnos.Datos;

namespace WinFormsAppAlumnos.Clases
{
    public class Alumno
    {
        /*
         *      ATRIBUTOS
         */
        public int Id { get; set; }
        public string Nombre { set; get; }
        public string Apellido { set; get; }
        public string Documento { set; get; }
        public string Telefono { set; get; }
        public string Mail { set; get; }
        public decimal Cuota { set; get; }
        public DateTime FechaNAcimiento { set; get; }

        private AccesoDatos ac = new AccesoDatos();

        /*
         *      METODOS SIN INTERACCION CON DB
         */

        /// <summary>
        ///     Entrega un String con los datos principales de un
        ///     profesor
        /// </summary>
        /// <returns> </returns>
        public string MostrarDatosAlumno()
        {
            return $"ID {Id} Nombre {Nombre} Apellido {Apellido}{Environment.NewLine}";
        }

        /*
          *      METODOS CON INTERACCION CON DB
          */

        public int AgregarEnDb()
        {
            string query = $"insert into alumnos (Nombre, Apellido, Documento, Telefono, Mail, Cuota, FechaNacimiento)";
            query += $"values('{this.Nombre}', '{this.Apellido}', '{this.Documento}', '{this.Telefono}', " +
                $" '{this.Mail}', {this.Cuota}, '{this.FechaNAcimiento.ToString("yyyyMMdd")}') ";
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

        public int ActualizarEnDb(Alumno alumnoAActualizar)
        {
            string query = $"update alumnos set Nombre = '{alumnoAActualizar.Nombre}', " +
                $"Apellido='{alumnoAActualizar.Apellido}', " +
                $"Documento='{alumnoAActualizar.Documento}', " +
                $"Telefono = '{alumnoAActualizar.Telefono}', " +
                $"Mail = '{alumnoAActualizar.Mail}', " +
                $"Cuota = {alumnoAActualizar.Cuota}, " +
                $"FechaNacimiento = '{alumnoAActualizar.FechaNAcimiento:yyyyMMdd}' " +
                $"where id = {alumnoAActualizar.Id}";
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

        public int EliminarEnDb(int idAlumnoEliminar)
        {
            string query = $"delete alumnos where id={idAlumnoEliminar}";
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

        public Alumno GetAlumnoPorId(int alumnoId)
        {
            try
            {
                string select = $"select * from Alumnos where id={alumnoId}";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);


                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }

                Alumno alumnoADevovlerConDatosDelaBaseDeDatos = new Alumno();
                foreach (DataRow dr in dt.Rows)
                {
                    alumnoADevovlerConDatosDelaBaseDeDatos.Id = Convert.ToInt32(dr["Id"]);
                    alumnoADevovlerConDatosDelaBaseDeDatos.Nombre = dr["Nombre"].ToString();
                    alumnoADevovlerConDatosDelaBaseDeDatos.Apellido = dr["Apellido"].ToString();
                    alumnoADevovlerConDatosDelaBaseDeDatos.Documento = dr["Documento"].ToString();
                    alumnoADevovlerConDatosDelaBaseDeDatos.Telefono = dr["Telefono"].ToString();
                    alumnoADevovlerConDatosDelaBaseDeDatos.Mail = dr["Mail"].ToString();
                    alumnoADevovlerConDatosDelaBaseDeDatos.Cuota = Convert.ToDecimal(dr["Cuota"]);
                    alumnoADevovlerConDatosDelaBaseDeDatos.FechaNAcimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                }

                return alumnoADevovlerConDatosDelaBaseDeDatos;
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

        public List<Alumno> GetTodosLosAlumnos()
        {
            try
            {
                string select = $"select * from Alumnos ";
                SqlCommand command = new SqlCommand(select);
                DataTable dt = ac.execDT(command);

                if (dt.Rows.Count <= 0)
                {
                    //no se encuentra pedido para actualizar estado
                    return null;
                }

                List<Alumno> alumnosADevovlerConDatosDelaBaseDeDatos = new List<Alumno>();
                foreach (DataRow dr in dt.Rows)
                {
                    Alumno AlumnoAuxiliar = new Alumno();
                    AlumnoAuxiliar.Id = Convert.ToInt32(dr["Id"]);
                    AlumnoAuxiliar.Nombre = dr["Nombre"].ToString();
                    AlumnoAuxiliar.Apellido = dr["Apellido"].ToString();
                    AlumnoAuxiliar.Documento = dr["Documento"].ToString();
                    AlumnoAuxiliar.Telefono = dr["Telefono"].ToString();
                    AlumnoAuxiliar.Mail = dr["Mail"].ToString();
                    AlumnoAuxiliar.Cuota = Convert.ToDecimal(dr["Cuota"]);
                    AlumnoAuxiliar.FechaNAcimiento = Convert.ToDateTime(dr["FechaNacimiento"]);
                    //agrego a la lista
                    alumnosADevovlerConDatosDelaBaseDeDatos.Add(AlumnoAuxiliar);
                }

                return alumnosADevovlerConDatosDelaBaseDeDatos;
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
