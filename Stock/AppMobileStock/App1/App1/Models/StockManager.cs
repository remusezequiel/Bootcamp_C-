using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class StockManager : BaseDTO
    {
        public int IdDeposito { get; set; }

        public string CodigoArticulo { get; set; }

        public decimal? Cantidad { get; set; }

        public int Accion { get; set; }
    }
}
