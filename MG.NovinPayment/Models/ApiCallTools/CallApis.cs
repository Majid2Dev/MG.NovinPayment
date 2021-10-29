using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MG.NovinPayment.Models.ApiCallTools
{
    public class CallApis : ICallApis
    {
        public async Task<T> CallingApiAsync<T>(string apiUrl, object value) where T : new()
        {

            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(apiUrl);

                client.DefaultRequestHeaders.Accept.Clear();
                var json = JsonConvert.SerializeObject(value);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var w = await client.PostAsync(apiUrl, content);
                HttpResponseMessage response = w;
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}