using Newtonsoft.Json;
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
        IEnumerable<LoginViewModal> logins;

        public LoginConnectAPI() {
            logins = null;
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
                    logins = readTask.Result;
                }
            }
            return logins;
        }

        public IEnumerable<LoginViewModal> GetVerifyLogin(string url, string filter)
        {
            logins = null;
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
                    logins = readTask.Result;
                }
            }
            return logins;
        }

        public LoginViewModal PostAccount(string url, LoginViewModal l)
        {
            LoginViewModal login = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);

                var postTask = client.PostAsJsonAsync<LoginViewModal>("mainLogin", l);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LoginViewModal>();
                    readTask.Wait();
                    login = readTask.Result;
                }
            }
            return login;
        }

        public IEnumerable<LoginViewModal> GetAccountTest()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);
                var responseTask = client.GetAsync("test");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<LoginViewModal[]>();
                    readTask.Wait();
                    logins = readTask.Result;
                }
            }
            return logins;
        }


    }
}