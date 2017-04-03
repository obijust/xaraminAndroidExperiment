using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace WeatherApp
{
    class DataService
    {
        public static async Task<dynamic> getDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            var clientResponse = await client.GetAsync(queryString);

            dynamic data = null;

            string jsonData = clientResponse.Content.ReadAsStringAsync().Result;
            data = JsonConvert.DeserializeObject(jsonData);
            
            return data; 
        }
    }
}
