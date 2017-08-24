using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class Divida : ClasseBase
    {
        public string Nome { get; set; }
        public decimal ValorDaDivida { get; set; }
        public eStatusDaDivida Situacao { get; set; }
        public DateTime DataDeVencimento { get; set; }
    }
}
