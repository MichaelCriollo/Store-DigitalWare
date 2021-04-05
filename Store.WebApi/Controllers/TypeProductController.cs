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
    [RoutePrefix("api/TypeProduct")]
    public class TypeProductController : BaseController
    {

        private TypeProductBL typeProductBL;

        /// <summary>
        /// Constructor
        /// </summary>
        public TypeProductController()
        {
            typeProductBL = new TypeProductBL();
        }

        /// <summary>
        /// Api Find All Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllTypeProduct")]
        public HttpResponseMessage FindAll()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                IEnumerable<TypeProduct> TypesFound = typeProductBL.FindAll();
                if (TypesFound != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, TypesFound);
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
                SaveError(ex, "AllTypeProduct", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }
    }
}
