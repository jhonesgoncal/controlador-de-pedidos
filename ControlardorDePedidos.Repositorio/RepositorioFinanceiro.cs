using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioFinanceiro : RepositorioGenerico<Financeiro>
    {
        RepositorioCompra respositorioCompra = new RepositorioCompra();
        RepositorioDivida repositorioDivida = new RepositorioDivida();
        RepositorioVenda repositorioVenda = new RepositorioVenda();
        public override void Adicione(Financeiro item)
        {

            item.TotalCompras = respositorioCompra.TotalDeCompras();
            item.TotalDividas = repositorioDivida.TotalDeDivida();
            item.TotalVendas = repositorioVenda.TotalDeVendas();
            base.Adicione(item);
        }

    }
}
