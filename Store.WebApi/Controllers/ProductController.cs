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
    [RoutePrefix("api/Product")]
    public class ProductController : BaseController
    {

        private ProductBL productBL;

        public ProductController()
        {
            productBL = new ProductBL();
        }

        /// <summary>
        /// Api create product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProduct")]
        public HttpResponseMessage Create(Product product)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                Product ProductCreate = productBL.Create(product);
                response = Request.CreateResponse(HttpStatusCode.OK, ProductCreate);
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
        /// Api Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateProduct")]
        public HttpResponseMessage Update(Product product)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            bool bUpdate = false;
            try
            {
                bUpdate = productBL.Update(product);
                if (bUpdate)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, bUpdate);
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
                SaveError(ex, "UpdateProduct", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }

        /// <summary>
        /// Api Delete Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("DeleteProduct")]
        public HttpResponseMessage Delete(Product product)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                productBL.Delete(product);
                response = Request.CreateResponse(HttpStatusCode.OK, true);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.ex = ex;
                SaveError(ex, "DeleteProduct", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }

        [HttpPost]
        [Route("FindProduct")]
        public HttpResponseMessage Find(Product product)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                IEnumerable<Product> Products = productBL.Find(product).ToList();
                if (Products != null && Products.Count() > 0)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, Products);
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
                SaveError(ex, "FindProduct", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;

        }

        /// <summary>
        /// Api update Product
        /// </summary>
        /// <param name="IdProduct"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("FindByIdProduct")]
        public HttpResponseMessage FindById([FromBody] int IdProduct)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                Product product = productBL.FindById(IdProduct);
                if (product != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, product);
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
                SaveError(ex, "FindByIdProduct", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }

            return response;
        }

        /// <summary>
        /// Api Find All Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AllProduct")]
        public HttpResponseMessage FindAll()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                IEnumerable<Product> ProductsFound = productBL.FindAll();
                if (ProductsFound != null)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK, ProductsFound);
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
                SaveError(ex, "AllProduct", ErrorLogLevel.ERROR);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, errorLog);
            }
            return response;
        }
    }
}
