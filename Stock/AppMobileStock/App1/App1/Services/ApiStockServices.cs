using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    public class ApiStockServices
    {
        /***************  
         *  ATRIBUTOS  
         ***************/
        public HttpClient Client { get; set; }
        public string URL { get; set; }
        public string ErrorLog { get; set; }


        public ApiStockServices()
        {
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };

            this.Client = new HttpClient(httpClientHandler);

            this.URL = "https://192.168.0.9:45455/api/Stock";            
        }

        /***************  
         *  METODOS
         ***************/
        public async Task<StockDTO> SendStock(StockDTO stockDTO)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
               (message, cert, chain, errors) => { return true; };

            using (HttpClient client = new HttpClient(httpClientHandler))
            {

                string url = this.URL;
                //string url = this.URLDeposit.Replace("?", "") + $"/CheckStock";

                client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                string content = JsonConvert.SerializeObject(stockDTO);

                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

                //var result = await client.PostAsync(url.Replace("?", ""), body);
                var result = await client.PostAsync(url, body);
                //leo respuesta
                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    var datos = JsonConvert.DeserializeObject<StockDTO>(data);
                    return datos;
                }
                else
                {
                    return null;
                }
            }
        }

        public async Task<StockDTO> SendPutStock(StockDTO stockDTO)
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback =
               (message, cert, chain, errors) => { return true; };

            using (HttpClient client = new HttpClient(httpClientHandler))
            {

                string url = this.URL;
                //string url = this.URLDeposit.Replace("?", "") + $"/CheckStock";

                client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                string content = JsonConvert.SerializeObject(stockDTO);

                StringContent body = new StringContent(content, Encoding.UTF8, "application/json");

                //var result = await client.PostAsync(url.Replace("?", ""), body);
                var result = await client.PutAsync(url, body);
                //leo respuesta
                string data = await result.Content.ReadAsStringAsync();

                if (result.IsSuccessStatusCode)
                {
                    var datos = JsonConvert.DeserializeObject<StockDTO>(data);
                    return datos;
                }
                else
                {
                    return null;
                }
            }
        }


        public async Task<List<StockDTO>> GetStock()
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();

                httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    //client.Timeout = TimeSpan.FromMinutes(App.HttpClientTimeOut);
                    string url = $"{this.URL}";

                    ErrorLog += $"Inicio Get order con url {url}";
                    //client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                    client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                    HttpResponseMessage response = await client.GetAsync(url);
                    ErrorLog += $"Hice Get Async";
                    string data = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        ErrorLog += $"Recibi data";
                        var datos = JsonConvert.DeserializeObject<List<StockDTO>>(data);
                        return datos;
                    }
                    else
                    {
                        ErrorLog += $"Recibi error";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog += $"Error Ejecutando get  {ex.Message}";
                return null;
            }
        }

        public async Task<StockDTO> GetStockById(int id)
        {
            try
            {
                var httpClientHandler = new HttpClientHandler();

                httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, cert, chain, errors) => { return true; };

                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    //client.Timeout = TimeSpan.FromMinutes(App.HttpClientTimeOut);
                    string url = $"{this.URL}{id}";

                    ErrorLog += $"Inicio Get order con url {url}";
                    //client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0");
                    client.DefaultRequestHeaders.Accept.TryParseAdd("application/json");

                    HttpResponseMessage response = await client.GetAsync(url);
                    ErrorLog += $"Hice Get Async";
                    string data = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        ErrorLog += $"Recibi data";
                        var datos = JsonConvert.DeserializeObject<StockDTO>(data);
                        return datos;
                    }
                    else
                    {
                        ErrorLog += $"Recibi error";
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog += $"Error Ejecutando get  {ex.Message}";
                return null;
            }
        }

    }
}
