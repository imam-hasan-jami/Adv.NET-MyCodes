﻿using BLL.DTOs;
using BLL.Services;
using BookReviewSite.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookReviewSite.Controllers
{
    [Logged]
    [RoutePrefix("api/review")]
    public class ReviewController : ApiController
    {
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ReviewService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = ReviewService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("create")]
        public HttpResponseMessage Create([FromBody] ReviewDTO obj)
        {
            try
            {
                var data = ReviewService.Create(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update([FromBody] ReviewDTO obj)
        {
            try
            {
                var data = ReviewService.Update(obj);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = ReviewService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("{id}/details")]
        public HttpResponseMessage GetReviewDetails(int id)
        {
            try
            {
                var data = ReviewService.GetReviewDetails(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Review not found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("bybook/{id}")]
        public HttpResponseMessage GetReviewDetailsByBookId(int id)
        {
            try
            {
                var data = ReviewService.GetReviewDetailsByBookId(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Review not found" });
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
