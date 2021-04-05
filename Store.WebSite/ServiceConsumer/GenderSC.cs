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
    public class GenderSC
    {
        private string UrlWebApi;

        /// <summary>
        /// Constructor
        /// </summary>
        public GenderSC()
        {

        }

        /// <summary>
        /// Find All Genders
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Gender> FindAll()
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            try
            {
                IEnumerable<Gender> GenderFound = null;
                using (HttpClient client = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Gender/AllGender", ConfigurationManager.AppSettings["UrlApi"]);
                    client.BaseAddress = new Uri(UrlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = client.GetAsync(UrlWebApi).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            GenderFound = JsonConvert.DeserializeObject<IEnumerable<Gender>>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return GenderFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return GenderFound;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}