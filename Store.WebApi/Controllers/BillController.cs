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
    [RoutePrefix("api/Bill")]
    public class BillController : BaseController
    {
        private BillBL billBL;

        public BillController()
        {
            billBL = new BillBL();
        }

        /// <summary>
        /// Api create Bill
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddBill")]
        public HttpResponseMessage Create(Bill bill)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                Bill BillCreate = billBL.Create(bill);
                response = Request.CreateResponse(HttpStatusCode.OK, BillCreate);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.ex = ex;
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }

        /// <summary>
        /// Api Delete Bill
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("DeleteBill")]
        public HttpResponseMessage Delete(Bill bill)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                billBL.Delete(bill);
                response = Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.ex = ex;
                SaveError(ex, "DeleteBill", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }

        /// <summary>
        /// Api update Bill
        /// </summary>
        /// <param name="IdBill"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FindByIdBill")]
        public HttpResponseMessage FindById([FromBody] int IdBill)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                Bill bill = billBL.FindById(IdBill);
                if (bill != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, bill);
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
                SaveError(ex, "FindByIdBill", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }

            return response;
        }

        /// <summary>
        /// Api Find All Bills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllBill")]
        public HttpResponseMessage FindAll()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                IEnumerable<Bill> BillsFound = billBL.FindAll();
                if (BillsFound != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, BillsFound);
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
                SaveError(ex, "AllBill", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }

    }
}
