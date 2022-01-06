using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProjetoFinaAPIRest.Models
{
    public class Ingresso
    {
        [Key]
        public int Id { get; set; }

        public double ValorFinal { get; set; }

        public int TipoIngressoId { get; set; }
        public int EventoId { get; set; }
        public int PessoaId { get; set; }
        public virtual TipoIngresso? TipoIngresso { get; set; }
        public virtual Evento? Evento { get; set; }
        public virtual Pessoa? Pessoa { get; set; }

     
        public double CalculaValorIngresso (double desconto)
        {
            ValorFinal -= (desconto/100);
            return ValorFinal; 
        }



        public Ingresso()
        {
        }
    }
}
