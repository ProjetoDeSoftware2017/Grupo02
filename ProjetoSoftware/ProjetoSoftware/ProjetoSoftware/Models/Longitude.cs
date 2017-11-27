using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoSoftware.Models
{
    public class Longitude
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Longiteude { get; set; }
        public string Latitude { get; set; }
    }
}