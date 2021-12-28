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

    public class PaisService : IPaisService
    {
        string endpoint = "https://api.mercadolibre.com/classified_locations/countries/";

        // aca lo ideal es crear una tabla de paises con sus codigos y una columna llamada Autorizado
        List<string> paisesNoAutorizados = new List<string>() { "BR", "CO" };

        /// <summary>
        /// Devuelve los datos de un pais
        /// </summary>
        /// <param name="codigo">string</param>
        /// <returns></returns>
        public Pais Get(string codigo)
        {
            Pais pais = new Pais();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(endpoint);

            if (string.IsNullOrEmpty(codigo))
                return null;

            if (!paisesNoAutorizados.Where(x => x == codigo.ToUpper()).Any())
            {
                HttpResponseMessage response = new HttpResponseMessage();
                try
                {
                    var p = client.GetAsync(codigo);
                    response = p.Result;

                }
                catch
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

                if (response.IsSuccessStatusCode)
                {
                    pais = response.Content.ReadAsAsync<Pais>().Result;

                }
                else
                {
                    throw new HttpResponseException(response.StatusCode);

                }

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            }

            

            return pais;


        }

    }
}