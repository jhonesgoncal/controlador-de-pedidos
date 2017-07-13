using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlardorDePedidos.Model;

namespace ControlardorDePedidos.Repositorio
{
    public class Contexto : DbContext
    {
        public Contexto() : base("DefaultConnection") {  }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
   
}
