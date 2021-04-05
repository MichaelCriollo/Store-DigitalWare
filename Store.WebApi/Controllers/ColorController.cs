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
    [RoutePrefix("api/Color")]
    public class ColorController : BaseController
    {
        private ColorBL colorBL;

        /// <summary>
        /// Contructor
        /// </summary>
        public ColorController()
        {
            colorBL = new ColorBL();
        }

        /// <summary>
        /// Api Find All Colors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllColor")]
        public HttpResponseMessage FindAll()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                IEnumerable<Color> ColorsFound = colorBL.FindAll();
                if (ColorsFound != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, ColorsFound);
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
                SaveError(ex, "AllColor", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }
    }
}