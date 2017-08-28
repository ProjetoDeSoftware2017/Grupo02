using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoSoftware.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class Contexto : DbContext
    {
        public Contexto() : base("Contexto")
        {

        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Longitude> Longitude { get; set; }
        public DbSet<Naufrago> Naufrago { get; set; }
    }
}