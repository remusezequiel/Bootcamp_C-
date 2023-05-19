using AutoMapper;
using CodigoComun.Datos;
using CodigoComun.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Modelo.DTO
{
    public class ArticuloDTO : BaseDTO
    {
        /*****************
         *   ATRIBUTOS 
         *****************/
        private AccesoDatos ac = new AccesoDatos();
        public int Id { get; set; }
        public string Nombre { set; get; }
        public string Marca { get; set; }
        public decimal MinimoStock { get; set; }
        public string Proveedor { get; set; }
        public decimal Precio { get; set; }
        public string Codigo { get; set; }

        /// <summary>
        ///     Tomoa un ArticuloDTO, lo mapea y retorna un Articulo
        /// </summary>
        /// <param name="articuloDTO"></param>
        /// <returns></returns>
        public Articulo GetArticulo(ArticuloDTO articuloDTO) 
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticuloDTO, Articulo>());
            var mapper = new Mapper(config);
            
            return mapper.Map<Articulo>(articuloDTO); ;
        }
    }
}
