using ControladorDePedidos.Model;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioVenda : RepositorioGenerico<Venda>
    {
        public override void Adicione(Venda item)
        {
            if(item.Cliente != null)
            {
                var clienteOriginal = contexto.Set<Cliente>().Find(item.Cliente.Codigo);
                item.Cliente = clienteOriginal;
            }
                
            base.Adicione(item);
        }

        public List<Venda> ListePorCliente(int codigoDoCliente)
        {
            contexto = new Contexto();
            return contexto.Set<Venda>().Where(x => x.Cliente.Codigo == codigoDoCliente).ToList();
        }

        public override void Atualize(Venda item)
        {
            var original = contexto.Set<Venda>().Find(item.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(item);
            if (item.Cliente != null)
            {
                var clienteOriginal = contexto.Set<Cliente>().Find(item.Cliente.Codigo);
                original.Cliente = clienteOriginal;
                contexto.Cliente.Attach(original.Cliente);
            }
            contexto.SaveChanges();
        }

        public override void Excluir(Venda item)
        {
            try
            {
                contexto.Set<ItemDaVenda>().RemoveRange(item.ItensDaVenda);
                var original = contexto.Set<Venda>().Find(item.Codigo);
                contexto.Set<Venda>().Remove(original);
                contexto.SaveChanges();
            }
            catch (DbUpdateException )
            {
                MessageBox.Show("Não é possivel exluir esse elemento, pois ele possi itens associados.");
            }
        }

       


    }
}
