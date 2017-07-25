using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioItemDaVenda
    {
        private Contexto contexto;

        public RepositorioItemDaVenda()
        {
            contexto = new Contexto();
        }

        public void Adicione(ItemDaVenda itemDaVenda )
        {
            var vendaOriginal = contexto.Set<Venda>().Find(itemDaVenda.Venda.Codigo);
            itemDaVenda.Venda = vendaOriginal;
            var produtoOriginal = contexto.Set<Produto>().Find(itemDaVenda.Produto.Codigo);
            itemDaVenda.Produto = produtoOriginal;
            contexto.Set<ItemDaVenda>().Add(itemDaVenda);
            contexto.SaveChanges();
        }

        public void Atualize(ItemDaVenda itemDaVenda)
        {
            var original = contexto.Set<ItemDaVenda>().Find(itemDaVenda.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(itemDaVenda);
            contexto.SaveChanges();
        }

        public List<ItemDaVenda> Liste()
        {
            contexto = new Contexto();
            var lista = contexto.Set<ItemDaVenda>().ToList();
            return lista;
        }
        public List<ItemDaVenda> Liste(int CodigoDaVenda)
        {
            contexto = new Contexto();
            var lista = contexto.Set<ItemDaVenda>().Where(x => x.Venda.Codigo == CodigoDaVenda).ToList();
            return lista;
        }

        public void Excluir(ItemDaVenda itemDaVenda)
        {
            var original = contexto.Set<ItemDaVenda>().Find(itemDaVenda.Codigo);
            contexto.Set<ItemDaVenda>().Remove(original);
            contexto.SaveChanges();
        }


    }
}
