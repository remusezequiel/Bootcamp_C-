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
    public class Articulo
    {
        /*****************
         *     ATRIBUTOS 
         *****************/
        private AccesoDatos ac = new AccesoDatos();
        public int Id { get; set; }
        public string Nombre { set; get; }
        public string Marca { get; set; }
        public decimal MinimoStock { get; set; }
        public string Proveedor { get; set; }
        public decimal Precio { get; set; }
        public string Codigo { get; set; }
        
        


        /*****************
         *      METODOS 
         *****************/
 
        public string MostrarVariblesPrincipales()
        {
            return "Numero/Id " + this.Id + " Nombre: "
                + this.Nombre + " Marca: " + this.Marca;
        }

        //Metodos 
        public string MostrarTodasVaribles()
        {
            return $"Numero/Id {Id} - Nombre {Nombre} - Marca {Marca} - Minimo Stock {MinimoStock} " +
                $"- Proveedor {Proveedor} - Precio {Precio}";
        }
    }
}
