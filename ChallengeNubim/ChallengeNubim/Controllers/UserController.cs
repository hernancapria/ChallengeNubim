using ChallengeNubim.DataAccess;
using ChallengeNubim.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChallengeNubim.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                UserService userService = new UserService();
                List<User> users = userService.GetAll();
                return Ok(users);
                
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }

        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                UserService userService = new UserService();
                User user = userService.Get(id);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]User value)
        {
            try
            {
                UserService userService = new UserService();
                userService.Insert(value);
                return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Operacion exitosa" };

            }
            catch (Exception ex)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.InternalServerError) { ReasonPhrase = ex.Message };
                return msg;

            }

        }
        


        [HttpPut]
        public HttpResponseMessage Put([FromBody]User value)
        {
            try
            {
                UserService userService = new UserService();
                userService.Update(value);
                return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Operacion exitosa" };
            }
            catch (Exception ex)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.InternalServerError) { ReasonPhrase = ex.Message };
                return msg;

            }

        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try 
            {
                UserService userService = new UserService();
                userService.Delete(id);
                return new HttpResponseMessage(HttpStatusCode.OK) { ReasonPhrase = "Operacion exitosa" };

            }
            catch (Exception ex)
            {
                var msg = new HttpResponseMessage(HttpStatusCode.InternalServerError) { ReasonPhrase = ex.Message };
                return msg;

            }
        
        }
    }
}
