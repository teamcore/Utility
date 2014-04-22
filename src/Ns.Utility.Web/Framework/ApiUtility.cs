using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Ns.Utility.Web.Framework
{
    public class ApiUtility
    {
        public static HttpClient GetClient()
        {
            string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
            var client = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });
            client.BaseAddress = new Uri(baseUrl);
            return client;
        }


        public static async Task<IEnumerable<T>> GetAsync<T>(string relativeUrl)
        {
            IEnumerable<T> result = new Collection<T>();
            using (var client = GetClient())
            {
                var response = await client.GetAsync(relativeUrl);
                if(response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsAsync<IEnumerable<T>>();
                    if(content != null)
                    {
                        result = content.Result;
                    }
                }
            }

            return result;
        }

        public static async Task<T> GetAsyncById<T>(string relativeUrl, int id)
        {
            T result = default(T);
            using (var client = GetClient())
            {
                var response = await client.GetAsync(string.Format("{0}/{1}", relativeUrl, id));
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsAsync<T>();
                    if (content != null)
                    {
                        result = content.Result;
                    }
                }
            }

            return result;
        }

        public static async Task<bool> PostAsync<T>(string relativeUrl, T model)
        {
            var result = false;
            using (var client = GetClient())
            {
                var response = await client.PostAsJsonAsync<T>(relativeUrl, model);
                result = response.IsSuccessStatusCode;
            }

            return result;
        }

        public static async Task<bool> PutAsync<T>(string relativeUrl, T model)
        {
            var result = false;
            using (var client = GetClient())
            {
                var response = await client.PutAsJsonAsync<T>(relativeUrl, model);
                result = response.IsSuccessStatusCode;
            }

            return result;
        }

        public static async Task<bool> DeleteAsync(string relativeUrl)
        {
            var result = false;
            using (var client = GetClient())
            {
                var response = await client.DeleteAsync(relativeUrl);
                result = response.IsSuccessStatusCode;
            }

            return result;
        }
    }
}