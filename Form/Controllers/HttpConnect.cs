using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Configuration;
using WebAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace Form.Controllers
{
    public class HttpConnect
    {
        IEnumerable<CustomerViewModal> i = null;

        public HttpConnect() { }

        public IEnumerable<CustomerViewModal> GetData(string url)
        {
            i = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerViewModal[]>();
                    readTask.Wait();
                    i = readTask.Result;
                }
            }
            return i;
        }

        public IEnumerable<CustomerViewModal> GetData(string url, string filter)
        {
            i = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);
                var responseTask = client.GetAsync(url + "?filter=" + filter);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerViewModal[]>();
                    readTask.Wait();
                    i = readTask.Result;
                }
            }
            return i;
        }

        public CustomerViewModal PostNewInfor(string url, CustomerViewModal t)
        {
            CustomerViewModal insert = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);
                var postTask = client.PostAsJsonAsync<CustomerViewModal>(url, t);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerViewModal>();
                    readTask.Wait();
                    insert = readTask.Result;
                }
            }
            return insert;
        }

        public bool DelData(string url, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);
                var delelteTask = client.DeleteAsync(url + "/" + id);
                delelteTask.Wait();
                return delelteTask.Result.IsSuccessStatusCode;
            }
        }

        public bool EditData(string url, CustomerViewModal t)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UriLink"]);
                //var resTask = client.GetAsync(url + "?id=" + t.id);
                var resTask = client.PutAsJsonAsync<CustomerViewModal>(url + "/" + t.CustomerID, t);

                resTask.Wait();
                return resTask.Result.IsSuccessStatusCode;
            }
        }

        public IEnumerable<LoginViewModal> GetVerifyLogin(string url, string filter)
        {
            IEnumerable<LoginViewModal> l = null;
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


        public IEnumerable<LoginViewModal> GetAccount(string url)
        {
            IEnumerable<LoginViewModal> t = null;
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
                    t = readTask.Result;
                }
            }
            return t;
        }


    }
}