using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using CodigoComun.Datos;
using CodigoComun.Datos.Repository;
using CodigoComun.Entities.DTO;
using CodigoComun.Entities;
using CodigoComun.Modelo;
using CodigoComun.Modelo.DTO;
using Codigo_Comun.Negocio;
using System.Reflection;
using System.Collections;

namespace CodigoComun.Negocio
{
    public class ArticuloServices
    {
        /****************************  
         *          ATRIBUTOS
         ****************************/
        private ArticulosRepository articulosRepository = new ArticulosRepository();
        private Articulo articulo = new Articulo();
        private ArticuloDTO articuloDTO = new ArticuloDTO();
        private StockDTO stockDTO = new StockDTO();
        private List<StockDTO> stockDTOs = new List<StockDTO>();
        private StockServices stockServices = new StockServices();

        /****************************  
        *          GETS
        ****************************/
        /*-----------------------GetById-------------------------------*/
        /// <summary>
        ///  Devuelve los datos el Articulo correspondiente al Id
        ///  Pasado
        /// </summary>
        /// <param name="idArticulo"></param>
        /// <returns></returns>
        public ArticuloDTO GetByID(int idArticulo) {
            articulo = articulosRepository.GetById(idArticulo);
            return articuloDTO.GetArticuloDTO(articulo);
        }

        /*-----------------------GetAll-------------------------------*/
        public List<ArticuloDTO> GetAll()
        {
            List<Articulo> articulos = articulosRepository.GetAll();
            return articuloDTO.GetAllArticuloDTO(articulos);
        }

        /***********  
         *  A.B.M 
         ***********/

        /*-----------------------Add-------------------------------*/
        public ArticuloDTO Add(ArticuloDTO articuloDTOToAdd)
        {
            try {

                bool existe = IsCodeInDB(articuloDTOToAdd);
                if (existe == false)
                {
                    // Add
                    Articulo articuloToAdd = articuloDTOToAdd.GetArticulo(articuloDTOToAdd);
                    articuloDTOToAdd.Origen = "Services: Metodo Update";
                    if (articulosRepository.AddOnDB(articuloToAdd) == 1)  //se hizo bien
                    {
                        articuloDTOToAdd.HuboError = false;
                        articuloDTOToAdd.Mensaje = "Articulo Agregado con Exito";
                        return articuloDTOToAdd;
                    }
                    else //se hizo mal
                    {
                        articuloDTOToAdd.HuboError = true;
                        articuloDTOToAdd.Mensaje = "No se pudo agregar el Articulo";
                        return articuloDTOToAdd;
                    }
                }
                else {
                    articuloDTOToAdd.HuboError = true;
                    articuloDTOToAdd.Mensaje = "El codigo ya existe. Ingrese otro";
                    return articuloDTOToAdd;
                }
            }
            catch (Exception ex)
            {
                articuloDTOToAdd.HuboError = true;
                articuloDTOToAdd.Mensaje = $"Hubo una excepcion dando el alta al Articulo: \n - Origen: {articuloDTO.Origen} \n Excepcion: {ex.Message}";
                return articuloDTOToAdd;
            }
        }

        /*-----------------------Delete-------------------------------*/
        public ArticuloDTO Delete(int idArticuloToDelete)
        {   
            try {
                articuloDTO.Origen = "Services: Metodo Delete";
                if (ArticuloConStock(idArticuloToDelete) == false)
                {
                    // Delete
                    if (articulosRepository.DeleteOnDB(idArticuloToDelete) == 1)
                    {
                        articuloDTO.Mensaje = "Articulo Eliminado con Exito";
                        return articuloDTO;
                    }
                    else
                    {                 
                        articuloDTO.HuboError = true;
                        articuloDTO.Mensaje = "No se pudo eliminar el Articulo";
                        return articuloDTO;
                    }
                }
                else {                    
                    articuloDTO.HuboError = true;
                    articuloDTO.Mensaje = "El articulo tiene stock. No se puede Eliminar.";
                    return articuloDTO;
                }
            }
            catch (Exception ex)
            {
                articuloDTO.HuboError = true;
                articuloDTO.Mensaje = $"Hubo una excepción eliminando al Articulo: \n - Origen: {articuloDTO.Origen} \n Excepcion: {ex.Message}";
                return articuloDTO;
            }
        }

        /*-----------------------Update-------------------------------*/
        public ArticuloDTO Update(ArticuloDTO articuloDTOToUpdate)
        {
            try 
            {
               
                bool existe = IsCodeInDB(articuloDTOToUpdate);
                if (existe == false)
                {
                    articulo = articuloDTO.GetArticulo(articuloDTOToUpdate);
                    if (articulosRepository.UpdateOnDB(articulo) == 1)
                    {
                        articuloDTOToUpdate.Origen = "Services: Metodo Update";
                        articuloDTOToUpdate.Mensaje = "Articulo Modificado con exito";
                        return articuloDTOToUpdate;
                    }
                    else
                    {
                        articuloDTOToUpdate.Origen = "Services: Metodo Update";
                        articuloDTOToUpdate.HuboError = true;
                        articuloDTOToUpdate.Mensaje = "No se pudo Modificar el Articulo";
                        return articuloDTOToUpdate;
                    }
                }
                else
                {
                    articuloDTOToUpdate.HuboError = true;
                    articuloDTOToUpdate.Mensaje = "El codigo ya existe. Ingrese otro";
                    return articuloDTOToUpdate;
                }
            }
            catch (Exception ex)
            {
                articuloDTOToUpdate.Origen = "Services: Metodo Update";
                articuloDTOToUpdate.HuboError = true;
                articuloDTOToUpdate.Mensaje = $"Hubo una excepción actualizando al Articulo: \n - Origen: {articuloDTO.Origen} \n Excepcion: {ex.Message}";
                return articuloDTOToUpdate;
            }
        }




        
        /********************  
         *  VALIDACIONES 
         ********************/
        #region Validaciones

        /// <summary>
        ///  Me dice si el articulo del id esta en stock
        /// </summary>
        /// <param name="idArticulo"></param>
        /// <returns></returns>
        public bool ArticuloConStock(int idArticulo)
        {
            stockDTOs = stockServices.GetAll();
            foreach (StockDTO stockDTO in stockDTOs)
            {
                if (stockDTO.IdArticulo == idArticulo)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Se fija si el codigo del articulo pasado
        ///     como parametro esta en la base de datos.
        /// </summary>
        /// <param name="articuloDTO"></param>
        /// <returns>
        ///     true -> si el existe el codigo del articulo 
        ///     false -> si no hay articulo
        /// </returns>
        public bool IsCodeInDB(ArticuloDTO articuloDTO) 
        {
            articulo = articulosRepository.GetByCode(articuloDTO.Codigo);
            if (articulo != null)
            {
                if (articuloDTO.Codigo.ToLower() == articulo.Codigo.ToLower() && articuloDTO.Id != articulo.Id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public ArticuloDTO IsCodeInDBDevuelveIdOCero(ArticuloDTO articuloDTO)
        {
            articulo = articulosRepository.GetByCode(articuloDTO.Codigo);
            if (articulo != null)
            {
                if (articuloDTO.Codigo.ToLower() == articuloDTO.Codigo.ToLower() &&
                    articuloDTO.Id != articulo.Id)
                {
                    return this.GetByID(articulo.Id);
                }
                else
                {
                    articuloDTO.Id = 0;
                    return articuloDTO;
                }
            }
            else
            {
                articuloDTO.Id = 0;
                return articuloDTO;
            }

            //List<ArticuloDTO> articuloDTOs = this.GetAll();
            //// Validaciones
            //foreach (ArticuloDTO art in articuloDTOs)
            //{
            //    if (articuloDTO.Codigo.ToLower() == art.Codigo.ToLower() && articuloDTO.Id != art.Id)
            //    {
            //        return art;
            //    }
            //}
            //articuloDTO.Id = 0;
            //return articuloDTO;
        }
        #endregion
    }
}
