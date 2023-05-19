using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodigoComun.Modelo.DTO
{
    public class BaseDTO
    {
        public string Origen { set; get; }
        public string Mensaje { set; get; }
        public bool HuboError { set; get; }
    }
}
