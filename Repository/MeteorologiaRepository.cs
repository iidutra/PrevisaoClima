using Dapper;
using PrevisaoClima.Interface;
using PrevisaoClima.Model;
using System.Data;

namespace PrevisaoClima.Repository
{
    public class MeteorologiaRepository
    {
        public class RepositorioMeteorologia : IRepositorioMeteorologia
        {
            private readonly IDbConnection _db;

            public RepositorioMeteorologia(IDbConnection db)
            {
                _db = db;
            }

            public async Task SalvarDadosMeteorologicosAsync(DadosMeteorologicos dados)
            {
                var sql = @"
                    INSERT INTO DadosMeteorologicos (Umidade, Intensidade, CodigoIcao, PressaoAtmosferica, Vento, DirecaoVento, Condicao, CondicaoDesc, Temp, AtualizadoEm)
                    VALUES (@Umidade, @Intensidade, @CodigoIcao, @PressaoAtmosferica, @Vento, @DirecaoVento, @Condicao, @CondicaoDesc, @Temp, @AtualizadoEm);
                ";

                await _db.ExecuteAsync(sql, new
                {
                    dados.Umidade,
                    dados.Intensidade,
                    dados.CodigoIcao,
                    dados.PressaoAtmosferica,
                    dados.Vento,
                    dados.DirecaoVento,
                    dados.Condicao,
                    dados.CondicaoDesc,
                    dados.Temp,
                    AtualizadoEm = dados.AtualizadoEm // Converta para SQL DateTime, se necessário
                });
            }

            public async Task RegistrarErroAsync(LogError log)
            {
                var sql = @"
                    INSERT INTO LogError (Mensagem, StackTrace, TipoErro, DataHora, Metodo, Servico, EndPoint, RequestPayload, ResponseStatusCode)
                    VALUES (@Mensagem, @StackTrace, @TipoErro, @DataHora, @Metodo, @Servico, @EndPoint, @RequestPayload, @ResponseStatusCode);
                ";

                await _db.ExecuteAsync(sql, log);
            }

        }
    }
}
