namespace PrevisaoClima.Interface
{
    public interface IServicoMeteorologia
    {
        Task ColetarEArmazenarDadosMeteorologicosAsync();
    }
}
