using ControladorDePedidos.Model;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Windows;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioCompra : RepositorioGenerico<Compra>
    {
        public override void Excluir(Compra item)
        {
            try
            {
                contexto.Set<ItemDaCompra>().RemoveRange(item.ItensDaCompra);
                var original = contexto.Set<Compra>().Find(item.Codigo);
                contexto.Set<Compra>().Remove(original);
                contexto.SaveChanges();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Não é possivel exluir esse elemento, pois ele possi itens associados.");
            }
        }

        
    }
}
