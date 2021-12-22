using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ChallengeNubim2.Entities;
using ChallengeNubim2.Services;
using System.IO;

namespace ChallengeNubim2
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            try
            {
                CurrencyService currencies = new CurrencyService();

                // llamar GetAllCurrencies y deserializar el json q devuelve a un objeto List
                var jsonCurrencies = currencies.GetAllCurrencies();
                List<Currency> lstCurr = JsonConvert.DeserializeObject<List<Currency>>(jsonCurrencies);

                // esta lista va a contener la lista anterior y las cotizaciones de cada moneda
                List<Currency> lstWithConversion = new List<Currency>();


                // recorrerlo y por cada moneda consultar su cotizacion con respecto al dolar
                // asignar el objeto con el resultado de la cotizacion en la propiedad to_dolar
                foreach (var curr in lstCurr)
                {
                    Currency currWithConversion = new Currency();
                    currWithConversion.id = curr.id;
                    currWithConversion.description = curr.description;
                    currWithConversion.symbol = curr.symbol;
                    currWithConversion.decimal_places = curr.decimal_places;

                    // se arranca la Task llamando a la funcion asincrona GetDolarConversion
                    Task<CurrencyConversion> callTask = Task.Run(() => currencies.GetDolarConversion(curr.id));

                    // la instruccion es para q espere a q termine de ejecutar la funcion asyncrona para continuar
                    // ya que como tarda mas el programa sigue de largo
                    await callTask;

                    CurrencyConversion currencyConversion = callTask.Result;

                    // se completa el objeto con el dato q falta q es la cotizacion
                    currWithConversion.to_dolar = currencyConversion;
                    lstWithConversion.Add(currWithConversion);

                }

                var jsonLstWithConversion = JsonConvert.SerializeObject(lstWithConversion);

                // guardar en un txt el resultado serializado a un json 
                File.AppendAllText("ResultadoCotizaciones.txt", jsonLstWithConversion + Environment.NewLine);

                // guardar los ratios en un csv
                File.WriteAllLines("ResultadoRatio.csv", lstWithConversion.Select(x => string.Join(",", x.to_dolar.ratio)));

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se produjo un error");
                Console.WriteLine($"Mensaje: " + ex.Message);

            }
            

        }


    }


}
