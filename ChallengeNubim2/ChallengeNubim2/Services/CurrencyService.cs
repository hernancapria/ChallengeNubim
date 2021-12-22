using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ChallengeNubim2.Entities;

namespace ChallengeNubim2.Services
{
    public class CurrencyService
    {
        private string endpointCurrencies = "https://api.mercadolibre.com/currencies/";
        private string endpointCurrenciesConversiones = "https://api.mercadolibre.com/currency_conversions/search?from={0}&to=USD";
        
        public string GetAllCurrencies() 
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add("Content-Type:application/json");
                    client.Headers.Add("Accept:application/json");
                    var result = client.DownloadString(endpointCurrencies);
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<CurrencyConversion> GetDolarConversion(string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                string endpointCurrenciesConversionesReplaced = string.Format(endpointCurrenciesConversiones, id);
                HttpResponseMessage response = new HttpResponseMessage();
                response = await client.GetAsync(endpointCurrenciesConversionesReplaced);
                CurrencyConversion currency = new CurrencyConversion();
                if (response.IsSuccessStatusCode)
                {
                    currency = response.Content.ReadAsAsync<CurrencyConversion>().Result;

                }
                return currency;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
    }

}