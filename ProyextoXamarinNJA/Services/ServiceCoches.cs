using Newtonsoft.Json;
using ProyextoXamarinNJA.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProyextoXamarinNJA.Services
{
    public class ServiceCoches
    {
        private String url;
        public ServiceCoches()
        {
            this.url = "https://apiproyectonja.azurewebsites.net/";
        }

        public async Task<T> CallApiAsync<T>(String request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    T data = JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public async Task<List<Coche>> GetCochesAsync(int id)
        {
            String request = "api/Coches/GetCoches/" + id;
            List<Coche> coches = await this.CallApiAsync<List<Coche>>(request);
            return coches;
        }
    }
}
