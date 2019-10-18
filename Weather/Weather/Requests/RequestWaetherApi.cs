using System.Net;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Weather.Requests
{
    public static class RequestWaetherApi
    {
        //Requisição para API Weather
        private static string URL = "http://localhost:5000/Weather.WebAPI/api/WeatherForecast";

        //Não está sendo possível instalar o nuget Newtonsoft.Json, teria que analisar melhor para entender o porque do problema, talves alguma incompatibilidade com versão
        //static readonly JsonSerializer _serializer = new JsonSerializer();
        public async static Task<List<WaetherApiDto>> GetAllAsyncWaetherApi()
        {
            HttpClient client = new HttpClient();
            var retorno = await client.GetAsync(URL);

            if (retorno.StatusCode == HttpStatusCode.OK)
            {

                //JsonConvert.DeserializeObject<List<WaetherApiDto>>(retorno.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                //Criei uma nova instancia do retorno pois não estou conseguindo realizar o deserializer do objeto de retorno da requisição
                var result = new List<WaetherApiDto>();
                return result;
            }
            else
            {
                return null;
            }
        }

        public async static Task<bool> PostAsyncWaetherApi(WaetherApiDto city)
        {
            HttpClient client = new HttpClient();

            var json = "{\"CityId\":\"" + city.CityId
                   + "\",\"Name\":\"" + city.Name + "\", "
                   + "\",\"Waether\":\"" + city.Waether + "\", "
                   + "\",\"Temperature\":\"" + city.Temperature + "\"}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var retorno = await client.PostAsync(URL, content);

            return retorno.StatusCode == HttpStatusCode.OK ? true : false;
        }

        public async static Task<bool> UpdateAsyncWaetherApi(WaetherApiDto city)
        {
            HttpClient client = new HttpClient();

            var json = "{\"CityId\":\"" + city.CityId
                   + "\",\"Name\":\"" + city.Name + "\", "
                   + "\",\"Waether\":\"" + city.Waether + "\", "
                   + "\",\"Temperature\":\"" + city.Temperature + "\"}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var retorno = await client.PutAsync(URL, content);

            return retorno.StatusCode == HttpStatusCode.OK ? true : false;
        }

        public async static Task<bool> DeleteAsyncWaetherApi(int cityId)
        {
            HttpClient client = new HttpClient();

            var url = string.Join(URL, "?id=", cityId);
            var retorno = await client.DeleteAsync(url);

            return retorno.StatusCode == HttpStatusCode.OK ? true : false;
        }
    }
}