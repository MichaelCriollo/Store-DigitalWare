using Newtonsoft.Json;
using Store.Entity.Dto;
using Store.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Store.WebSite.ServiceConsumer
{
    public class DetailBillSC
    {
        private string UrlWebApi;

        /// <summary>
        /// Find DetaillBill by Entity Filter
        /// </summary>
        /// <param name="DetailBill">Entity Filter</param>
        /// <returns>IEnumerable Entity DetailBill</returns>
        public IEnumerable<DetailBill> Find(DetailBill DetailBill)
        {
            string responseMessage = string.Empty;
            IEnumerable<DetailBill> DetailBillsFound = new List<DetailBill>();
            ErrorLog errorLog = new ErrorLog();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}DetailBill/FindDetailBill", ConfigurationManager.AppSettings["UrlApi"]);
                    httpClient.BaseAddress = new Uri(UrlWebApi);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = httpClient.PostAsync(UrlWebApi, DetailBill, new System.Net.Http.Formatting.JsonMediaTypeFormatter { }).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case System.Net.HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            DetailBillsFound = JsonConvert.DeserializeObject<IEnumerable<DetailBill>>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return DetailBillsFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return DetailBillsFound;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}