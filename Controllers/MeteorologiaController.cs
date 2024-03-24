using Microsoft.AspNetCore.Mvc;
using PrevisaoClima.Interface;
using PrevisaoClima.Service;

namespace PrevisaoClima.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeteorologiaController : ControllerBase
    {
        private readonly IServicoMeteorologia _servicoMeteorologia;

        public MeteorologiaController(IServicoMeteorologia servicoMeteorologia)
        {
            _servicoMeteorologia = servicoMeteorologia ?? throw new ArgumentNullException(nameof(servicoMeteorologia));
        }

        /// <summary>
        /// Coleta e armazena dados meteorológicos.
        /// </summary>
        /// <returns>Uma resposta de sucesso ou erro.</returns>
        /// <response code="200">Dados meteorológicos coletados e armazenados com sucesso.</response>
        /// <response code="500">Ocorreu um erro ao coletar e armazenar os dados meteorológicos.</response>
        [HttpGet("ColetarEArmazenar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ColetarEArmazenarDadosMeteorologicos()
        {
            try
            {
                await _servicoMeteorologia.ColetarEArmazenarDadosMeteorologicosAsync();
                return Ok("Dados meteorológicos coletados e armazenados com sucesso.");
            }
            catch (Exception ex)
            {
                // Em uma aplicação real, use um logger para registrar esse erro também
                return StatusCode(500, $"Ocorreu um erro ao coletar e armazenar os dados meteorológicos: {ex.Message}");
            }
        }
    }
}
