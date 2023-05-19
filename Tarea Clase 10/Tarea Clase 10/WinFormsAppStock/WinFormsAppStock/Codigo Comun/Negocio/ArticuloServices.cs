using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Codigo_Comun.Modelo.DTO;
using CodigoComun.Datos;
using CodigoComun.Datos.Repository;
using CodigoComun.Modelo;


namespace CodigoComun.Negocio
{
    public class ArticuloServices
    {
        /****************************  
         *          GETS
         ****************************/
        /// <summary>
        ///     Busca un Articulo por Id. Si lo encuentra
        ///     lo devuelve el Articulo, si no lo encuentra
        ///     devuelve null
        /// </summary>
        /// <param name="idArticulo"></param>
        /// <returns>
        ///     Si sale bien -> El articulo pedido
        ///     Si sale mal  -> null
        /// </returns>
        public Articulo GetPorID(int idArticulo) { 
            ArticulosRepository articuloRepository = new ArticulosRepository();
            if (idArticulo > 0)
            {
                return articuloRepository.GetArticuloById(idArticulo);
            }
            else {
                return null;
            }           
        }

        public Articulo GetPorNombre(string nombreArticulo)
        {
            ArticulosRepository articuloRepository = new ArticulosRepository();
            return articuloRepository.GetArticuloByName(nombreArticulo);
          
        }


        /// <summary>
        /// Toma una lista de articulos
        /// </summary>
        /// <returns>
        ///     La lista de articulos
        /// </returns>
        public List<Articulo> GetTodosPorID()
        {
           ArticulosRepository articuloRepository = new ArticulosRepository();            
           return articuloRepository.GetAllArticulosById();            
        }

        /****************************  
         *  ALTA-BAJA-MODIFICACION
         ****************************/
        /// <summary>
        ///     Agrega un articulo a la base de datos
        ///     si estos cumplen con los requicitos necesarios
        /// </summary>
        /// <param name="articuloToAdd"></param>
        /// <returns>
        ///     mensajes correspondiente a cada validación
        /// </returns>
        public ArticuloDTO AgregarArticulo(ArticuloDTO articulosDTOAAgregar)
        {
            try
            {
                ArticulosRepository articulosRepository = new ArticulosRepository();
                ArticuloServices articuloServices = new ArticuloServices();
                List<Articulo> articulos = articulosRepository.GetAllArticulosById();
                // Validaciones
                foreach (Articulo art in articulos)
                {
                    if (articulosDTOAAgregar.Codigo == art.Codigo)
                    {
                        articulosDTOAAgregar.Mensaje = "El Codigo del articulo ya existe. Elija otro codigo";
                        return articulosDTOAAgregar;
                    }
                }
                // Add
                var articuloToAdd = articulosDTOAAgregar.GetArticulo(articulosDTOAAgregar);
                if (articulosRepository.AddArticuloDB(articuloToAdd) == 1)
                {
                    //se hizo bien
                    articulosDTOAAgregar.Mensaje = "Articulo Agregado con Exito";
                    return articulosDTOAAgregar;
                    
                }
                else
                {
                    //se hizo mal
                    articulosDTOAAgregar.HuboError = true;
                    articulosDTOAAgregar.Mensaje = "No se pudo agregar el Articulo";
                    return articulosDTOAAgregar;
                }
            }
            catch (Exception ex){
                articulosDTOAAgregar.HuboError = true;
                articulosDTOAAgregar.Mensaje = $"Ocurrio una excepción agregando al articulo {ex.Message}";
                return articulosDTOAAgregar;
            }   
            
        }

        /// <summary>
        ///     Elimina un articulo si este existe
        /// </summary>
        /// <param name="idArticuloToDelete"></param>
        /// <returns></returns>
        public string EliminarArticulo(int idArticuloToDelete)
        {
            ArticulosRepository articulosRepository = new ArticulosRepository();
            // Validaciones

            // Delete
            if (articulosRepository.DeleteArticluloOnDB(idArticuloToDelete) == 1)
            {
                return "Articulo Eliminado con Exito";
            }
            else
            {
                //se hizo mal
                return "No se pudo eliminar el Articulo";
            }
        }

        /// <summary>
        ///     Modifica un articulo si este existe
        /// </summary>
        /// <param name="articuloToModify"></param>
        /// <returns></returns>
        public string ModificarArticulo(Articulo articuloToModify)
        {
            ArticulosRepository articulosRepository = new ArticulosRepository();
            // Validaciones

            // Modificaciones
            if (articulosRepository.ModifyArticuloOnDB(articuloToModify) == 1)
            {
                return "El Articulo fue modificado con exito";
            }
            else
            {
                return "No se pudo modificar el Articulo.";
            }
        }

        /**************************************/

    }
}
