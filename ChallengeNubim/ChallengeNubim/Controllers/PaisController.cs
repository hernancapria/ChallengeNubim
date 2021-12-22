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
    public class PaisController : ApiController
    {

        [HttpGet]
        [Route("api/Pais/{codigo}")]
        public IHttpActionResult Get(string codigo)
        {
            PaisService paisService = new PaisService();
            try
            {
                var p = paisService.Get(codigo);
                return Ok(p);

            }
            catch (HttpResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.Unauthorized)
                    return Unauthorized();
                else if (ex.Response.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest();
                else
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
