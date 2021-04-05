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
    [RoutePrefix("api/DetailBill")]
    public class DetailBillController : BaseController
    {
        private DetailBillBL detailBillBL;
        
        public DetailBillController()
        {
            detailBillBL = new DetailBillBL();
        }

        [HttpPost]
        [Route("FindDetailBill")]
        public HttpResponseMessage Find(DetailBill DetailBill)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                IEnumerable<DetailBill> DetailBills = detailBillBL.Find(DetailBill).ToList();
                if (DetailBills != null && DetailBills.Count() > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, DetailBills);
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
                SaveError(ex, "FindDetailBill", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;

        }
    }
}
