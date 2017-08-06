using System.Collections.Generic;

namespace ControladorDePedidos.Model
{
    public class Cliente : ClasseBase
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public List<Venda> Vendas { get; set; }
    }
}
