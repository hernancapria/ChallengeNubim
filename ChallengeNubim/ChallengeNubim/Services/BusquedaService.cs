using ChallengeNubim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using ChallengeNubim.Contracts;

namespace ChallengeNubim.Services
{
    public class BusquedaService : IBusquedaService
    {
        string endpoint = "https://api.mercadolibre.com/sites/MLA/search?q={0}";

        /// <summary>
        /// Devuelve todas las ofertas de un producto
        /// </summary>
        /// <param name="producto">string</param>
        /// <returns></returns>
        public ResultadoBusqueda Get(string producto)
        {
            if (string.IsNullOrEmpty(producto))
            {
                return null;
            }

            ResultadoBusqueda resultadoBusqueda = new ResultadoBusqueda();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();
            endpoint = string.Format(endpoint, producto);

            try
            {
                var b =  client.GetAsync(endpoint);
                response = b.Result;
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
             

            if (response.IsSuccessStatusCode)
            {
                resultadoBusqueda = response.Content.ReadAsAsync<ResultadoBusqueda>().Result;

            }
            else
            {
                throw new HttpResponseException(response.StatusCode);

            }


            return resultadoBusqueda;







        }


    }
}