using System.ComponentModel.DataAnnotations.Schema;

namespace ControladorDePedidos.Model
{
    public class ItemDaVenda : ClasseBase
    {
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }
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
     
    }
}
