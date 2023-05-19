using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class BaseDTO
    {
        public string Origen { set; get; }
        public string Mensaje { set; get; }
        public bool HuboError { set; get; }
    }
}
