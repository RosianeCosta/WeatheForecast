using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Weather.WebApi.Dtos;

namespace Weather.WebApi.Request
{
    public static class RequestApi
    {
        public static string urlAPI = "http://http://api.openweathermap.org/data/2.5/weather?id=3470127&appid=2bac87e0cb16557bff7d4ebcbaa89d2f&lang=pt&units=metric";

        public async static Task<CitiesDto> RequisitionGetAsync(string id)
        {
            var URL = urlAPI;
            HttpClient client = new HttpClient();

            var json = "{\"id\":\"" + id + "\",\"appid\":\"" + "2bac87e0cb16557bff7d4ebcbaa89d2f&lang=pt&units=metric" + "\"}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var retorno = await client.GetAsync(urlAPI);

            if (retorno.StatusCode == HttpStatusCode.OK)
            {
                if (retorno.Content.ReadAsStringAsync().GetAwaiter().GetResult() == "true")
                {
                  //  return true;
                }
                else
                {
                   // return false;
                }
            }
            else
            {
                //return false;
            }

            return new CitiesDto();
        }
    }
}
