using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProjetoFinaAPIRest.Models
{
    public class Portifolio
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }
        public string CaminhoFotoPrincipal { get; set; }

  
        public virtual ICollection<FotoPortifolio>? FotosPortifolio { get; set; }

        public Portifolio()
        {
        }
    }
}
