using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControladorDePedidos.Model;

namespace ControlardorDePedidos.Repositorio
{
    public class Contexto : DbContext
    {
        public Contexto() : base("DefaultConnection") {  }
        public DbSet<Marca> Marca { get; set; }
    }
   
}
