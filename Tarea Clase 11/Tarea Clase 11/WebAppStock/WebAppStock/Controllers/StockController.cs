﻿using Codigo_Comun.Negocio;
using CodigoComun.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAppStock.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {           
            return View();
        }
    }
}
