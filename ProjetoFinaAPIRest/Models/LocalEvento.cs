﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProjetoFinaAPIRest.Models
{
    public class LocalEvento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Local Do Evento")]
        public string Name { get; set; }

        [StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        [StringLength(100)]
        public string Logradouro { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; }

        [Required]
        [StringLength(100)]
        public string Cidade { get; set; }

        [Required]
        [StringLength(2), MinLength(2), MaxLength(2)]
        public string UF { get; set; }

        [Required]
        [StringLength(12)]
        [DataType(DataType.PostalCode)]
        public string CEP { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Evento>? Eventos { get; set; }
        public LocalEvento()
        {
        }
    }
}
