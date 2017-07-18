using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioItemDaCompra
    {
        private Contexto contexto;

        public RepositorioItemDaCompra()
        {
            contexto = new Contexto();
        }

        public void Adicione(ItemDaCompra itemDaCompra )
        {
            var ItemDaCompraOriginal = contexto.Set<ItemDaCompra>().Find(itemDaCompra.Codigo);
            if (ItemDaCompraOriginal != null)
                throw new ApplicationException("Já existe uma venda com esse código");
            contexto.Set<ItemDaCompra>().Add(itemDaCompra);
            contexto.SaveChanges();
        }

        public void Atualize(ItemDaCompra itemDaCompra)
        {
            var original = contexto.Set<ItemDaCompra>().Find(itemDaCompra.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(itemDaCompra);
            contexto.SaveChanges();
        }

        public List<ItemDaCompra> Liste()
        {
            contexto = new Contexto();
            var lista = contexto.Set<ItemDaCompra>().ToList();
            return lista;
        }

        public void Excluir(ItemDaCompra itemDaCompra)
        {
            var original = contexto.Set<ItemDaCompra>().Find(itemDaCompra.Codigo);
            contexto.Set<ItemDaCompra>().Remove(original);
            contexto.SaveChanges();
        }


    }
}
