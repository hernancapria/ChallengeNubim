using ChallengeNubim.Entities;
using ChallengeNubim.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChallengeNubim.Controllers
{
    public class BusquedaController : ApiController
    {
        [HttpGet]
        [Route("api/Busqueda/{producto}")]
        public IHttpActionResult Get(string producto)
        {
            BusquedaService busquedaService = new BusquedaService();
            try
            {
                ResultadoBusqueda resultadoBusqueda = new ResultadoBusqueda();
                resultadoBusqueda = busquedaService.Get(producto);
                return Ok(resultadoBusqueda);

            }
            catch 
            {
                return InternalServerError();
            }

        }

        // GET api/values/5
        public string Get()
        {
            return "value";
        }


        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
