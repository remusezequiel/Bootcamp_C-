using CodigoComun.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codigo_Comun.Entities.DTO
{
    public class StockManager : BaseDTO
    {
      
        public int IdDeposito { get; set; }

        public string CodigoArticulo { get; set; }

        public decimal? Cantidad { get; set; }

        public int Accion { get; set; }

    }
}
