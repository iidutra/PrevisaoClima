using Newtonsoft.Json;
using PrevisaoClima.Interface;
using PrevisaoClima.Model;

namespace PrevisaoClima.Service
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "https://brasilapi.com.br/api/cptec/v1/clima/capital";

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<DadosMeteorologicos[]> ChamarApiMeteorologiaAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_apiUrl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var dados = JsonConvert.DeserializeObject<DadosMeteorologicos[]>(content);

                return dados ?? Array.Empty<DadosMeteorologicos>();
            }
            catch (HttpRequestException httpEx)
            {
                // Tratar erro específico de HTTP
                throw new Exception("Erro ao chamar a API meteorológica.", httpEx);
            }
            catch (JsonException jsonEx)
            {
                // Tratar erro de deserialização
                throw new Exception("Erro ao desserializar os dados da API meteorológica.", jsonEx);
            }
        }
    }
}
