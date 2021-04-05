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
    public class TypeProductSC
    {
        private string UrlWebApi;

        /// <summary>
        /// Constructor
        /// </summary>
        public TypeProductSC()
        {

        }

        /// <summary>
        /// Find All Types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeProduct> FindAll()
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            try
            {
                IEnumerable<TypeProduct> TypeProductFound = null;
                using (HttpClient client = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}TypeProduct/AllTypeProduct", ConfigurationManager.AppSettings["UrlApi"]);
                    client.BaseAddress = new Uri(UrlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = client.GetAsync(UrlWebApi).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            TypeProductFound = JsonConvert.DeserializeObject<IEnumerable<TypeProduct>>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return TypeProductFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return TypeProductFound;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}