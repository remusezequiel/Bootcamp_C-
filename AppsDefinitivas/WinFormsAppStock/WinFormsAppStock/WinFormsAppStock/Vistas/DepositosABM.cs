using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using CodigoComun.Entities;
using CodigoComun.Entities.DTO;
using CodigoComun.Modelo;
using CodigoComun.Negocio;

namespace WinFormsAppStock.Vistas
{
    public partial class DepositosABM : Form
    {
        /************** 
         * ATRIBUTOS 
         **************/
        public bool EstoyModificando { get; set; }


        /******************* 
        * CONSTRUCTORES 
        ********************/
        public DepositosABM()
        {
            InitializeComponent();
            EstoyModificando = false;
        }

        public DepositosABM(int idDepositoAModificar)
        {
            InitializeComponent();
            EstoyModificando = true;
            CargarDatosDepositoParaModificar(idDepositoAModificar);
        }

        /************ 
         * METODOS
         ************/
        /// <summary>
        ///     Carga los datos del deposito pedido en los textBox
        ///     del formulario
        /// </summary>
        /// <param name="idDepositoAModificar"></param>
        public void CargarDatosDepositoParaModificar(int idDepositoAModificar)
        {
            // Instancio un DepositoServices
            DepositoServices depositoServices = new DepositoServices();
            // Instancio un Deposito 
            DepositoDTO depositoEnDb = new DepositoDTO();
            
            // Guardo el deposito
            depositoEnDb = depositoServices.GetById(idDepositoAModificar);
            
            txtId.Text = idDepositoAModificar.ToString();
            txtCapacidad.Text = depositoEnDb.Capacidad.ToString();
            txtNombre.Text = depositoEnDb.Nombre;
            txtDireccion.Text = depositoEnDb.Direccion;
        }

        /// <summary>
        ///     Agrega los datos del formulario 
        ///     a la base de datos
        /// </summary>
        private void AgregarDeposito()
        {
            DepositoServices depositoServices = new DepositoServices();
            DepositoDTO depositoAGuardar = new DepositoDTO();

            try
            {
                depositoAGuardar = CargarDatosDepositoAgregar();
                if ( depositoAGuardar.Direccion == "" || depositoAGuardar.Nombre == "" )
                {
                    depositoAGuardar.Mensaje = "Todos los campos deben tener datos.";
                    MessageBox.Show(depositoAGuardar.Mensaje, "Cuidado!");
                }
                else if (depositoAGuardar.Origen == "Cargar") {

                    depositoAGuardar = depositoServices.Add(depositoAGuardar);
                    if (depositoAGuardar.HuboError == false)
                    {
                        MessageBox.Show(depositoAGuardar.Mensaje, "Operación Exitosa");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(depositoAGuardar.Mensaje, "Cuidado!");
                    }
                }
                else
                {
                    MessageBox.Show(depositoAGuardar.Mensaje, "Cuidado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio una Exepcion:{ex.Message}.\n\n  Verifique si agrego un Valores numericos en Capacidad", "Hubo un problema");
            }
        }

        /// <summary>
        ///     Modifica los datos del deposito pasado
        ///     segun los textBox del formulario
        /// </summary>
        private void ModificarDeposito()
        {
            DepositoServices depositoServices = new DepositoServices();
            DepositoDTO depositoAModificar = new DepositoDTO();
            
            try
            {
                depositoAModificar = CargarDatosDepositoModificar();
                if (depositoAModificar.Origen == "Cargar" &
                    depositoAModificar.Direccion != null &
                    depositoAModificar.Nombre != null)
                {
                    DepositoDTO depositoToUpdate = depositoServices.Update(depositoAModificar);
                    if (depositoToUpdate.HuboError == false)
                    {
                        MessageBox.Show(depositoToUpdate.Mensaje, "Operación Exitosa");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(depositoToUpdate.Mensaje, "Cuidado!");
                    }
                }
                else {
                    MessageBox.Show(depositoAModificar.Mensaje, "Cuidado!");
                }

            }
            catch(Exception ex) {
                MessageBox.Show($"Ocurrio una Exepcion:{ex.Message}.", "Hubo un problema");
            }


        }


        public DepositoDTO CargarDatosDepositoAgregar()
        {
            DepositoDTO carga = new DepositoDTO();
            decimal capacidadAux = 0;
            bool canConvert = decimal.TryParse(txtCapacidad.Text, out capacidadAux);
            if (canConvert == true)
            {                
                carga.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
                carga.Nombre = txtNombre.Text;
                carga.Direccion = txtDireccion.Text;
                carga.Origen = "Cargar";
                return carga;
            }
            else
            {
                carga.Mensaje = "La Cantidad es un valor numérico.\nNo ingrese caracteres.";
                carga.Origen = "NoCargar";
                return carga;
            }
        }

        public DepositoDTO CargarDatosDepositoModificar() 
        {
            DepositoDTO carga = new DepositoDTO();
            decimal capacidadAux = 0;
            bool canConvert = decimal.TryParse(txtCapacidad.Text, out capacidadAux);
            if (canConvert == true)
            {
                carga.Id = Convert.ToInt32(txtId.Text);
                carga.Capacidad = Convert.ToDecimal(txtCapacidad.Text);
                carga.Nombre = txtNombre.Text;
                carga.Direccion = txtDireccion.Text;
                carga.Origen = "Cargar";
                return carga;
            }
            else {
                carga.Mensaje = "La Cantidad es un valor numérico.\nNo ingrese caracteres.";
                carga.Origen = "NoCargar";
                return carga;
            }
        }
        
        /************ 
         * BOTONES 
         ************/
        /// <summary>
        ///     El boton agrega o modifica un deposito
        ///     segun de donde se ejecute ek formuladio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardarDeposito_Click_1(object sender, EventArgs e)
        {
            if (EstoyModificando == true)
            {
                ModificarDeposito();
            }
            else
            {
                AgregarDeposito();
            }
        }


        

    }
}
