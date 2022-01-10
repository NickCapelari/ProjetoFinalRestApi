using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProjetoFinaAPIRest.Models
{
    public class FotoPortifolio
    {
        [Key]
        public int Id { get; set; }
        public string CaminhoFoto { get; set; }
        public int PortifolioId { get; set; }


        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Portifolio? Portifolio { get; set; }

        public FotoPortifolio()
        {
        }
    }
}
