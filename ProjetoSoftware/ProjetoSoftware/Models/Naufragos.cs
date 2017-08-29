using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoSoftware.Models
{
    public class Naufragos
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data Ocorrido")]
        public DateTime DataOcorrido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Pais { get; set; }
        public string Local { get; set; }
        public string Motivo { get; set; }
        public string Obs { get; set; }

        [Key]
        public int IdNaufrago { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
    }
}