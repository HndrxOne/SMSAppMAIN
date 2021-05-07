using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace SMSWeb.Repository
{
    public class WebApiRepository
    {
        public HttpClient Client { get; set; }
        public WebApiRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebApiUrl"].ToString());
        }
        public WebApiRepository(string strWebApiUrl)
        {
            Client = new HttpClient();

            if (strWebApiUrl.Substring(0, 4).ToUpper() == "HTTP")
            {
                Client.BaseAddress = new Uri(strWebApiUrl);
            }
            else
            {
                Client.BaseAddress = new Uri(ConfigurationManager.AppSettings[strWebApiUrl].ToString());
            }
            
        }
        public string ConfigurationValue(string keyValue)
        {
            return ConfigurationManager.AppSettings[keyValue].ToString();
        }
        public HttpResponseMessage GetResponse(string url)
        {
            return Client.GetAsync(url).Result;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            return Client.PostAsJsonAsync(url, model).Result;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            return Client.DeleteAsync(url).Result;
        }
    }
}