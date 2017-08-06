using System.Collections.Generic;
using System.Linq;
using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioItemDaVenda : RepositorioGenerico<ItemDaVenda>
    {
        public override void Adicione(ItemDaVenda itemDaVenda )
        {
            var vendaOriginal = contexto.Set<Venda>().Find(itemDaVenda.Venda.Codigo);
            itemDaVenda.Venda = vendaOriginal;

            var produtoOriginal = contexto.Set<Produto>().Find(itemDaVenda.Produto.Codigo);
            itemDaVenda.Produto = produtoOriginal;

            contexto.Set<ItemDaVenda>().Add(itemDaVenda);
            contexto.SaveChanges();
        }

       
        public List<ItemDaVenda> Liste(int CodigoDaVenda)
        {
            contexto = new Contexto();
            var lista = contexto.Set<ItemDaVenda>().Where(x => x.Venda.Codigo == CodigoDaVenda).ToList();
            return lista;
        }
    }
}
