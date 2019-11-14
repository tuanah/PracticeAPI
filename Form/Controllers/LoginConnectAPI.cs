using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebAPI.Models;

namespace Form.Controllers
{
    public class LoginConnectAPI
    {
        IEnumerable<LoginViewModal> l;

        public LoginConnectAPI() {
            l = null;
        }

        public IEnumerable<LoginViewModal> GetAccount(string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LoginViewModal[]>();
                    readTask.Wait();
                    l = readTask.Result;
                }
            }
            return l;
        }

        public IEnumerable<LoginViewModal> GetVerifyLogin(string url, string filter)
        {
            l = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);

                var responseTask = client.GetAsync(url + "?filter=" + filter);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LoginViewModal[]>();
                    readTask.Wait();
                    l = readTask.Result;
                }
            }
            return l;
        }



    }
}