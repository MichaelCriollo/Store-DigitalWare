using Store.BusinessLogic.Class;
using Store.Entity.Dto;
using Store.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store.WebApi.Controllers
{
    [RoutePrefix("api/Gender")]
    public class GenderController : BaseController
    {
        private GenderBL genderBL;

        /// <summary>
        /// Contructor
        /// </summary>
        public GenderController()
        {
            genderBL = new GenderBL();
        }

        /// <summary>
        /// Api Find All Genders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllGender")]
        public HttpResponseMessage FindAll()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                IEnumerable<Gender> GendersFound = genderBL.FindAll();
                if (GendersFound != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, GendersFound);
                }
                else
                {
                    response = Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.ex = ex;
                SaveError(ex, "AllGender", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }
    }
}
