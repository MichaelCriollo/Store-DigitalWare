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
    public class BillSC
    {

        private string UrlWebApi;

        /// <summary>
        /// Constructor
        /// </summary>
        public BillSC()
        {

        }

        /// <summary>
        /// Create Bill
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public Bill Create(Bill bill)
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            Bill BillCreate = new Bill();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Bill/AddBill", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlWebApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PostAsync(UrlWebApi, bill, new JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            BillCreate = JsonConvert.DeserializeObject<Bill>(responseMessage);
                            break;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                    return BillCreate;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Find Bill by Entity Filter
        /// </summary>
        /// <param name="Bill">Entity Filter</param>
        /// <returns>IEnumerable Entity Bill</returns>
        public IEnumerable<Bill> Find(Bill Bill)
        {
            string responseMessage = string.Empty;
            IEnumerable<Bill> BillsFound = new List<Bill>();
            ErrorLog errorLog = new ErrorLog();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Bill/FindBill", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlWebApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PostAsync(UrlWebApi, Bill, new System.Net.Http.Formatting.JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            BillsFound = JsonConvert.DeserializeObject<IEnumerable<Bill>>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return BillsFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return BillsFound;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find bill to id
        /// </summary>
        /// <param name="IdBill"></param>
        /// <returns></returns>
        public Bill FindById(int IdBill)
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            try
            {
                Bill BillFound = null;
                using (HttpClient client = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Bill/FindByIdBill", ConfigurationManager.AppSettings["UrlApi"]);
                    client.BaseAddress = new Uri(UrlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = client.PostAsync(UrlWebApi, IdBill, new System.Net.Http.Formatting.JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            BillFound = JsonConvert.DeserializeObject<Bill>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return BillFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return BillFound;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Find All Bills
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Bill> FindAll()
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            try
            {
                IEnumerable<Bill> BillFound = null;
                using (HttpClient client = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Bill/AllBill", ConfigurationManager.AppSettings["UrlApi"]);
                    client.BaseAddress = new Uri(UrlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = client.GetAsync(UrlWebApi).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            BillFound = JsonConvert.DeserializeObject<IEnumerable<Bill>>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return BillFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return BillFound;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Delete Bill
        /// </summary>
        /// <param name="bill"></param>
        /// <returns></returns>
        public Boolean Delete(Bill bill)
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            bool bDelete = false;
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Bill/DeleteBill", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlWebApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PutAsync(UrlWebApi, bill, new System.Net.Http.Formatting.JsonMediaTypeFormatter { }).Result;
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