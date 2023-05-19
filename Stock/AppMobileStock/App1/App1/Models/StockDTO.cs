using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class StockDTO : BaseDTO
    {
        public int Id { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdDeposito { get; set; }
        public decimal? Cantidad { get; set; }

      
    }
}
