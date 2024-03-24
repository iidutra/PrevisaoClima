using System.ComponentModel.DataAnnotations.Schema;

namespace PrevisaoClima.Model
{
    [Table("LogError")]
    public class LogError
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }
        public string StackTrace { get; set; }
        public string TipoErro { get; set; }
        public DateTime DataHora { get; set; }
        public string Metodo { get; set; }
        public string Servico { get; set; }
        public string EndPoint { get; set; }
        public string RequestPayload { get; set; }
        public int? ResponseStatusCode { get; set; }
    }

}
