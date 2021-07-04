using Newtonsoft.Json;
using poc.AspNet5.Domain.Interfaces.Services;
using poc.AspNet5.Ioc.Entities;
using System;
using System.Net.Http;

namespace poc.AspNet5.Domain.Services
{
    public class PrevisaoTempoService : IPrevisaoTempoService
    {
        public PrevisaoTempoCidade GetPrevisaoPorIp(string Ip)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.hgbrasil.com");
                var dados = client.GetAsync($"weather?key=c7a9e0c1&user_ip={Ip}");

                dados.Wait();
                var response = dados.Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseJson = response.Content.ReadAsStringAsync().Result;
                    var objetoJson = JsonConvert.DeserializeObject<PrevisaoTempo>(responseJson);

                    return objetoJson.results;
                }

                return null;
            }
        }
    }
}
