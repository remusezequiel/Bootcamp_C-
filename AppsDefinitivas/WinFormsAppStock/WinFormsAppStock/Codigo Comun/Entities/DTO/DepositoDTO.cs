using AutoMapper;
using CodigoComun.Entities;
using CodigoComun.Modelo.DTO;
using CodigoComun.Modelo;
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
            return mapper.Map<Deposito>(depositoDTO);           
        }

        public DepositoDTO GetDepositoDTO(Deposito deposito)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Deposito, DepositoDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<DepositoDTO>(deposito);
        }


        public List<Deposito> GetAllDepositos(List<DepositoDTO> depositosDTOList)
        {
            List<Deposito> depositosList = new List<Deposito>();
            foreach (var depo in depositosDTOList)
            {
                depositosList.Add(GetDeposito(depo));
            }
            return depositosList;
        }

        public List<DepositoDTO> GetAllDepositosDTO(List<Deposito> depositos)
        {
            List<DepositoDTO> depositosDTO = new List<DepositoDTO>();
            foreach (var depo in depositos)
            {
                depositosDTO.Add(GetDepositoDTO(depo));
            }
            return depositosDTO;
        }
    }
}
