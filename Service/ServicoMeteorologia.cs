using Newtonsoft.Json;
using PrevisaoClima.Interface;
using PrevisaoClima.Model;

namespace PrevisaoClima.Service
{
    public class ServicoMeteorologia : IServicoMeteorologia
    {
        private readonly IRepositorioMeteorologia _repositorio;
        private readonly IApiClient _apiClient;

        public ServicoMeteorologia(IRepositorioMeteorologia repositorio, IApiClient apiClient)
        {
            _repositorio = repositorio ?? throw new ArgumentNullException(nameof(repositorio));
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public async Task ColetarEArmazenarDadosMeteorologicosAsync()
        {
            try
            {
                var dadosMeteorologicos = await _apiClient.ChamarApiMeteorologiaAsync();
                if (dadosMeteorologicos != null && dadosMeteorologicos.Any())
                {
                    foreach (var dado in dadosMeteorologicos)
                    {
                        await _repositorio.SalvarDadosMeteorologicosAsync(dado);
                    }
                }
            }
            catch (Exception ex)
            {
                var logErro = new LogError
                {
                    Mensagem = ex.Message,
                    StackTrace = ex.StackTrace,
                    TipoErro = ex.GetType().Name,
                    DataHora = DateTime.UtcNow,
                    Metodo = nameof(ColetarEArmazenarDadosMeteorologicosAsync),
                };

                await _repositorio.RegistrarErroAsync(logErro);
            }
        }
    }
}
