﻿using ChallengeNubim.Contracts;
using ChallengeNubim.DataAccess;
using ChallengeNubim.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ChallengeNubim.Models;

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
                List<UsuarioModel> users = userService.GetAll();
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
                UsuarioModel user = userService.Get(id);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]UsuarioModel value)
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
        public HttpResponseMessage Put([FromBody]UsuarioModel value)
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
