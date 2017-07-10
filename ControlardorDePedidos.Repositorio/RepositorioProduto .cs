using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioProduto
    {
        private Contexto contexto;

        public RepositorioProduto()
        {
            contexto = new Contexto();
        }

        public void Adicione(Produto produto )
        {
            contexto.Set<Produto>().Add(produto);
            contexto.SaveChanges();
        }

        public void Atualize(Produto produto)
        {
            var original = contexto.Set<Produto>().Find(produto.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(produto);
            contexto.SaveChanges();
        }

        public List<Produto> Liste()
        {
            contexto = new Contexto();
            var lista = contexto.Set<Produto>().ToList();
            return lista;
        }

        public void Excluir(Produto produto)
        {
            var original = contexto.Set<Produto>().Find(produto.Codigo);
            contexto.Set<Produto>().Remove(original);
            contexto.SaveChanges();
        }


    }
}
