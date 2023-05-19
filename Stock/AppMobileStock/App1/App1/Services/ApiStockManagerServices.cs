﻿using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public class ApiStockManagerServices
    {
        public HttpClient Client { get; set; }
        public string URL { get; set; }
        public string ErrorLog { get; set; }


        public ApiStockManagerServices()
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            this.Client = new HttpClient(httpClientHandler);

            this.URL = "https://192.168.0.9:45455/api/StockManager/";
        }

        public async Task<StockManager> SendStockManager(StockManager stockManager)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };

            using (HttpClient client = new HttpClient(httpClientHandler))
            {

                string url = this.URL;
                //string url = this.URLDeposit.Replace("?", "") + $"/CheckStock";

                client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                string content = JsonConvert.SerializeObject(stockManager);

                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

                //var result = await client.PostAsync(url.Replace("?", ""), body);
                var result = await client.PostAsync(url, body);
                //leo respuesta
                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    var datos = JsonConvert.DeserializeObject<StockManager>(data);
                    return datos;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
