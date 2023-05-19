using AutoMapper;
using CodigoComun.Entities;
using CodigoComun.Modelo.DTO;
using CodigoComun.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CodigoComun.Negocio;

namespace CodigoComun.Entities.DTO
{
    public class StockDTO : BaseDTO
    {
       
        public int Id { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdDeposito { get; set; }
        public decimal? Cantidad { get; set; }


        public Stock GetStock(StockDTO stockDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StockDTO, Stock>());
            var mapper = new Mapper(config);
            return mapper.Map<Stock>(stockDTO);
        }

        public List<Stock> GetAllStock(List<StockDTO> stockDTOList)
        {
            List<Stock> stockList = new List<Stock>();
            foreach (var stock in stockDTOList)
            {
                stockList.Add(GetStock(stock));
            }
            return stockList;
        }


        public StockDTO GetStockDTO(Stock stock)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Stock, StockDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<StockDTO>(stock);
        }


        public List<StockDTO> GetAllStocksDTO(List<Stock> stock)
        {
            List<StockDTO> stockDTOs = new List<StockDTO>();
            foreach (var s in stock)
            {
                stockDTOs.Add(GetStockDTO(s));
            }
            return stockDTOs;
        }

        public string ArticuloName(int? idStockDTOAIdArticulo)
        {
            ArticuloDTO articuloDTO = new ArticuloDTO();
            ArticuloServices articuloServices = new ArticuloServices();

            articuloDTO = articuloServices.GetByID((int)idStockDTOAIdArticulo);
            return articuloDTO.Nombre;
        }

        public string DepositoName(int? idStockDTOAIdDeposito)
        {
            DepositoDTO depositoDTO = new DepositoDTO();
            DepositoServices depositoServices = new DepositoServices();

            depositoDTO = depositoServices.GetById((int)idStockDTOAIdDeposito);
            return depositoDTO.Nombre;
        }

    }
}

