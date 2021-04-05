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
    public class ColorSC
    {
        private string UrlWebApi;

        /// <summary>
        /// Constructor
        /// </summary>
        public ColorSC()
        {

        }

        /// <summary>
        /// Find All Colors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Color> FindAll()
        {
            string responseMessage = string.Empty;
            ErrorLog errorLog = new ErrorLog();
            try
            {
                IEnumerable<Color> ColorFound = null;
                using (HttpClient client = new HttpClient())
                {
                    UrlWebApi = string.Format("{0}Color/AllColor", ConfigurationManager.AppSettings["UrlApi"]);
                    client.BaseAddress = new Uri(UrlWebApi);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage GetResponse = client.GetAsync(UrlWebApi).Result;
                    switch (GetResponse.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            ColorFound = JsonConvert.DeserializeObject<IEnumerable<Color>>(responseMessage);
                            break;
                        case HttpStatusCode.NotFound:
                            return ColorFound;
                        case HttpStatusCode.InternalServerError:
                            responseMessage = GetResponse.Content.ReadAsStringAsync().Result;
                            errorLog = JsonConvert.DeserializeObject<ErrorLog>(responseMessage);
                            throw new Exception(errorLog.ex.Message, errorLog.ex.InnerException);
                    }
                }
                return ColorFound;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}