using AutoMapper;
using CodigoComun.Datos;
using CodigoComun.Entities.DTO;
using CodigoComun.Entities;
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
       
        public int Id { get; set; }
        public string Nombre { set; get; }
        public string Marca { get; set; }
        public decimal MinimoStock { get; set; }
        public string Proveedor { get; set; }
        public decimal Precio { get; set; }
        public string Codigo { get; set; }



        /*****************
         *   METODOS 
         *****************/

        public Articulo GetArticulo(ArticuloDTO articuloDTO) 
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ArticuloDTO, Articulo>());
            var mapper = new Mapper(config);
            return mapper.Map<Articulo>(articuloDTO);
        }

        public List<Articulo> GetAllArticulos(List<ArticuloDTO> articuloDTOList) 
        {
            List <Articulo> articulosList = new List<Articulo> ();
            foreach (var art in articuloDTOList) {
                articulosList.Add(GetArticulo(art));
            } 
            return articulosList;
        }



        public ArticuloDTO GetArticuloDTO(Articulo articulo)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Articulo, ArticuloDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<ArticuloDTO>(articulo);
        }


        public List<ArticuloDTO> GetAllArticuloDTO(List<Articulo> articulos)
        {
            List<ArticuloDTO> articulosDTO = new List<ArticuloDTO>();
            foreach (var art in articulos)
            {
                articulosDTO.Add(GetArticuloDTO(art));
            }
            return articulosDTO;
        }
    }
}
