using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControladorDePedidos.Model
{
    public class Compra : ClasseBase
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
                foreach (var item in ItensDaCompra)
                {
                    quantidade += item.Quantidade;
                }
                return quantidade;
            }
        }
        public virtual List<ItemDaCompra> ItensDaCompra { get; set; }
        public eStatusDaCompra Status { get; set; }
        [NotMapped]
        public decimal ValorTotal {
            get
            {
                decimal valor = 0;
                foreach(var item in ItensDaCompra)
                {
                    valor += item.ValorTotal;
                }
                return valor;
            }
       }
    }
}
