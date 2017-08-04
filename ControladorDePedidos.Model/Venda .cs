using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class Venda : ClasseBase
    {
        public DateTime DataDeCadastro { get; set; }
        public DateTime DataDeEfetivacao { get; set; }
        public DateTime DataDoRecebimento { get; set; }
        [NotMapped]
        public int QuantidadeDeProdutos
        {
            get
            {
                var quantidade = 0;
                foreach (var item in ItensDaVenda)
                {
                    quantidade += item.Quantidade;
                }
                return quantidade;
            }
        }
        public virtual List<ItemDaVenda> ItensDaVenda { get; set; }
        public eStatusDaVenda Status { get; set; }
        [NotMapped]
        public decimal ValorTotal {
            get
            {
                decimal valor = 0;
                foreach(var item in ItensDaVenda)
                {
                    valor += item.ValorTotal;
                }
                return valor;
            }
       }
    }
}
