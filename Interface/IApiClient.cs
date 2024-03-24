using PrevisaoClima.Model;

namespace PrevisaoClima.Interface
{
    public interface IApiClient
    {
        Task<DadosMeteorologicos[]> ChamarApiMeteorologiaAsync();
    }
}
