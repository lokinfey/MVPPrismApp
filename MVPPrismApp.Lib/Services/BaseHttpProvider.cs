using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using MVPPrismApp.Lib.Exceptions;
using Newtonsoft.Json;

namespace MVPPrismApp.Lib.Services
{
    public class BaseHttpProvider
    {
        protected string _apiURL;

        protected HttpClient GetClient()
        {
            return GetClient(_apiURL);
        }

        protected virtual HttpClient GetClient(string apiURL)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiURL);

            return client;
        }

        protected async Task<string> Get(string url)
        {
            using (HttpClient client = GetClient(url))
            {
                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        var ex = ResponseErrors(response);

                        var message = ex != null ? ex.Message : "";
                        throw new APIException(message, response.StatusCode);
                    }
                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException ex)
                {
                    throw new APIException("", false, ex);
                }
            }
        }

        Exception ResponseErrors(HttpResponseMessage response)
        {
            var httpErrorObject = response.Content.ReadAsStringAsync().Result;

            var anonymousErrorObject =
                new { message = "", ModelState = new Dictionary<string, string[]>() };

            // Deserialize:
            var deserializedErrorObject =
                JsonConvert.DeserializeAnonymousType(httpErrorObject, anonymousErrorObject);

            var ex = new Exception();

            // Sometimes, there may be Model Errors:
            if (deserializedErrorObject.ModelState != null)
            {
                var errors =
                    deserializedErrorObject.ModelState
                                            .Select(kvp => string.Join(". ", kvp.Value));
                for (int i = 0; i < errors.Count(); i++)
                {
                    // Wrap the errors up into the base Exception.Data Dictionary:
                    ex.Data.Add(i, errors.ElementAt(i));
                }
            }
            // Othertimes, there may not be Model Errors:
            else
            {
                var error =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(httpErrorObject);
                foreach (var kvp in error)
                {
                    // Wrap the errors up into the base Exception.Data Dictionary:
                    ex.Data.Add(kvp.Key, kvp.Value);
                }
            }
            return ex;
        }
    }
}
