using BLL.DTOs;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntroTierApp.Controllers
{
    public class PersonController : ApiController
    {
        [HttpGet]
        [Route("api/person/all")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var data = PersonService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Contact Support", Api = "api/person/all" });
            }
        }

        [HttpGet]
        [Route("api/person/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = PersonService.Get(id);
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Mesage = "Student not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Contact Support", Api = "api/person/" + id });
            }
        }

        [HttpPost]
        [Route("api/person/create")]
        public HttpResponseMessage Create(PersonDTO p)
        {
            try
            {
                var data = PersonService.Create(p);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Contact Support", Api = "api/person/create" });
            }
        }

        [HttpPut]
        [Route("api/person/update")]
        public HttpResponseMessage Update(PersonDTO p)
        {
            try
            {
                var data = PersonService.Update(p);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Contact Support", Api = "api/person/update" });
            }
        }

        [HttpDelete]
        [Route("api/person/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = PersonService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = "Contact Support", Api = "api/person/delete/" + id });
            }
        }
    }
}
