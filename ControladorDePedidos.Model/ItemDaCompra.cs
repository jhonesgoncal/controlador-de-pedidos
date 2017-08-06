using System.ComponentModel.DataAnnotations.Schema;

namespace ControladorDePedidos.Model
{
    public class ItemDaCompra : ClasseBase
    {
        public virtual Produto Produto { get; set; }
        public virtual Compra Compra { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        [NotMapped]
        public decimal ValorTotal
        {
            get
            {
                return Quantidade * Valor;
            }
        }
        [NotMapped]
        public int QuantidadeFinalEmEstoque {
            get
            {
              return  Produto.QuantidadeEmEstoque + Quantidade;
            }

        }
    }
}
