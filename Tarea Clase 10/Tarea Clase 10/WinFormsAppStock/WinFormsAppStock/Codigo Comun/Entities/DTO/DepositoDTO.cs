using AutoMapper;
using CodigoComun.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Entities.DTO 
{
    public class DepositoDTO : BaseDTO
    {
        public int Id { get; set; }
        public decimal? Capacidad { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public Deposito GetDeposito(DepositoDTO depositoDTO) 
        {   
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepositoDTO, Deposito>());
            var mapper = new Mapper(config);
            

            return mapper.Map<Deposito>(source: depositoDTO);
        }
    }
}
