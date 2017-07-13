using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlardorDePedidos.Model
{
    public class Marca
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}
