namespace ControladorDePedidos.Model
{
    public class Produto : ClasseBase
    {
        public string Nome { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public decimal ValorDeCompra { get; set; }
        public decimal ValorDeVenda { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int QuantidadeMinimaEmEstoque { get; set; }
        public int QuantidadeDesejavelEmEstoque { get; set; }
    }
}
