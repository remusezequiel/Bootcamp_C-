﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Entities.DTO
{
    internal class StockDTO : BaseDTO
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
    }
}
