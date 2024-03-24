using PrevisaoClima.Model;

namespace PrevisaoClima.Interface
{
    public interface IRepositorioMeteorologia
    {
        Task SalvarDadosMeteorologicosAsync(DadosMeteorologicos dados);
        Task RegistrarErroAsync(LogError log);
    }

}
