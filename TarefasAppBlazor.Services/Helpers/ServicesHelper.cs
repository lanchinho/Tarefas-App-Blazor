using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TarefasAppBlazor.Services.Model.Responses;
using TarefasAppBlazor.Services.Settings;

namespace TarefasAppBlazor.Services.Helpers
{
    /// <summary>
    /// Classe para implementarmos os tipos de requisições Http 
    /// que poderão ser feitas para a API
    /// </summary>
    public class ServicesHelper
    {
        private AuthenticationHeaderValue? _authenticationHeaderValue;        

        public ServicesHelper() { }

        public ServicesHelper(string accessToken)
        {
            _authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", accessToken);
        }

        /// <summary>
        /// Método genérico para requisições do tipo POST
        /// </summary>        
        public async Task<TResponse> Post<TRequest, TResponse>(string endpoint, TRequest request)
        {
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                var result = await httpClient.PostAsync($"{AppSettings.BaseUrl}{endpoint}", content);

                var response = ReadResponse(result);

                if (result.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<TResponse>(response)!;
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<ErrorResult>(response);
                    throw new Exception(error?.Message);
                }
            }
        }

        public async Task<TResponse> Put<TRequest, TResponse>(string endpoint, TRequest request)
        {
            //Serializar os dados da requisição em JSON
            var content = new StringContent(JsonConvert.SerializeObject(request),
                Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                //Fazendo a requisição para a API
                var result = await httpClient.PutAsync($"{AppSettings.BaseUrl}{endpoint}", content);
                var response = ReadResponse(result);

                if (result.IsSuccessStatusCode)
                    return JsonConvert.DeserializeObject<TResponse>(response)!;
                else
                {
                    var error = JsonConvert.DeserializeObject<ErrorResult>(response);
                    throw new Exception(error.Message);
                }
            }
        }

        public async Task<TResponse> Get<TResponse>(string endpoint)
        {
            using (var httpClient = new HttpClient())
            {
                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                var result = await httpClient.GetAsync($"{AppSettings.BaseUrl}{endpoint}");
                var response = ReadResponse(result);

                return JsonConvert.DeserializeObject<TResponse>(response)!;
            }
        }

        public async Task<TResponse> Get<TResponse>(string endpoint, Guid id)
        {
            using (var httpClient = new HttpClient())
            {
                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                //Fazendo a requisição para a API
                var result = await httpClient.GetAsync($"{AppSettings.BaseUrl}{endpoint}/{id}");
                var response = ReadResponse(result);

                return JsonConvert.DeserializeObject<TResponse>(response);
            }
        }

        public async Task<TResponse> Delete<TResponse>(string endpoint, Guid id)
        {
            using (var httpClient = new HttpClient())
            {
                if (_authenticationHeaderValue != null)
                    httpClient.DefaultRequestHeaders.Authorization = _authenticationHeaderValue;

                var result = await httpClient.DeleteAsync($"{AppSettings.BaseUrl}{endpoint}/{id}");
                var response = ReadResponse(result);

                return JsonConvert.DeserializeObject<TResponse>(response)!;
            }
        }       

        private static string ReadResponse(HttpResponseMessage result)
        {
            var builder = new StringBuilder();
            using (var r = result.Content)
            {
                var task = r.ReadAsStringAsync();
                builder.Append(task.Result);
            }

            return builder.ToString();
        }
    }
}
