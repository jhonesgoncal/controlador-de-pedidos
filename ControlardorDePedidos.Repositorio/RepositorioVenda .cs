using ControladorDePedidos.Model;
using System.Data.Entity.Infrastructure;
using System.Windows;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioVenda : RepositorioGenerico<Venda>
    {
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
