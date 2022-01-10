﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ProjetoFinaAPIRest.Models
{
    public class Evento
    {
        [Key]
        [Display(Name = "ID Evento: ")]
        public int Id { get; set; }

        [Display(Name = "Nome do Evento: ")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Display(Name = "Descrição do Evento: ")]
        [StringLength(300)]
        public string Descricao { get; set; }

        [Display(Name = "Data de Inicio: ")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data Encerramento: ")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }

        [Display(Name = "Valor do Ingresso: ")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }

        [Display(Name = "Local do Evento: ")]
        public int LocalEventoId { get; set; }


        [JsonIgnore]
        [IgnoreDataMember]
        public virtual LocalEvento? LocalEvento { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<Ingresso>? Ingressos { get; set; }

        
        
       


        public Evento()
        {

        }
    }
}
