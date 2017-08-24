namespace ControladorDePedidos.Model
{
    public class Financeiro : ClasseBase
    {
        public decimal Saldo { get; set; }
        public decimal TotalCompras { get; set; }
        public decimal TotalVendas { get; set; }
        public decimal TotalDividas { get; set; }
    }
}
