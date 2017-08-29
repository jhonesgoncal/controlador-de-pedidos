using ControladorDePedidos.Model;
using System.Linq;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioFinanceiro : RepositorioGenerico<Financeiro>
    {
        RepositorioItemDaCompra respositorioItemDaCompra = new RepositorioItemDaCompra();
        RepositorioDivida repositorioDivida = new RepositorioDivida();
        RepositorioItemDaVenda repositorioItemDaVenda = new RepositorioItemDaVenda();
        public override void Adicione(Financeiro item)
        {
            
            item.TotalCompras = respositorioItemDaCompra.TotalDeCompras();
            item.TotalDividas = repositorioDivida.TotalDeDivida();
            item.TotalVendas = repositorioItemDaVenda.TotalDeVendas();
            item.Saldo = calculaSaldo();
            base.Adicione(item);
        }

        public override void Atualize(Financeiro item)
        {
            item.TotalCompras = respositorioItemDaCompra.TotalDeCompras();
            item.TotalDividas = repositorioDivida.TotalDeDivida();
            item.TotalVendas = repositorioItemDaVenda.TotalDeVendas();
            item.Saldo += calculaSaldo();
            contexto.Set<Financeiro>().Add(item);
            contexto.SaveChanges();
        }

        public decimal calculaSaldo()
        {
            var total = repositorioItemDaVenda.TotalDeVendas() - (repositorioDivida.TotalDeDivida() + respositorioItemDaCompra.TotalDeCompras());
            if (contexto.Set<Financeiro>().Where(x => x.Codigo > 0).Count() == 0)
            {
                return total;
            }
            else
            {
                if(total > 0)
                {
                    return contexto.Set<Financeiro>().OrderByDescending(p => p.Codigo).Take(1).First()
                    .Saldo + total;
                }
                else
                {
                    return contexto.Set<Financeiro>().OrderByDescending(p => p.Codigo).Take(1).First()
                    .Saldo - total;
                }
               
            }
            
        }
       

    }
}
