using Newtonsoft.Json;
using Store.Entity.Dto;
using Store.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;

namespace Store.WebSite.ServiceConsumer
{
    public class ProductSC
    {
        private string UrlWebApi;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductSC()
        {

        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Product Create(Product product)
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            Product ProductCreate = new Product();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Product/AddProduct", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlWebApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PostAsync(UrlWebApi, product, new JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            ProductCreate = JsonConvert.DeserializeObject<Product>(responseMessage);
                            break;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                    return ProductCreate;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool Update(Product product)
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            bool bUpdate = false;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Product/UpdateProduct", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlWebApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PutAsync(UrlWebApi, product, new JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            bUpdate = JsonConvert.DeserializeObject<bool>(responseMessage);
                            break;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return bUpdate;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Find Product by Entity Filter
        /// </summary>
        /// <param name="Product">Entity Filter</param>
        /// <returns>IEnumerable Entity Product</returns>
        public IEnumerable<Product> Find(Product product)
        {
            string responseMessage = string.Empty;
            IEnumerable<Product> ProductsFound = new List<Product>();
            ErrorLog errorLog = new ErrorLog();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Product/FindProduct", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlWebApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PostAsync(UrlWebApi, product, new System.Net.Http.Formatting.JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            ProductsFound = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return ProductsFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return ProductsFound;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find product to id
        /// </summary>
        /// <param name="IdProduct"></param>
        /// <returns></returns>
        public Product FindById(int IdProduct)
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            try
            {
                Product ProductFound = null;
                using (HttpClient client = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Product/FindByIdProduct", ConfigurationManager.AppSettings["UrlApi"]);
                    client.BaseAddress = new Uri(UrlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = client.PostAsync(UrlWebApi, IdProduct, new System.Net.Http.Formatting.JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            ProductFound = JsonConvert.DeserializeObject<Product>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return ProductFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return ProductFound;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find All Products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> FindAll()
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            try
            {
                IEnumerable<Product> ProductFound = null;
                using (HttpClient client = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Product/AllProduct", ConfigurationManager.AppSettings["UrlApi"]);
                    client.BaseAddress = new Uri(UrlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = client.GetAsync(UrlWebApi).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            ProductFound = JsonConvert.DeserializeObject<IEnumerable<Product>>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return ProductFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return ProductFound;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Boolean Delete(Product product)
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            bool bDelete = false;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Product/DeleteProduct", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlWebApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PutAsync(UrlWebApi, product, new System.Net.Http.Formatting.JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            bDelete = Convert.ToBoolean(JsonConvert.DeserializeObject(responseMessage));
                            break;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return bDelete;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
