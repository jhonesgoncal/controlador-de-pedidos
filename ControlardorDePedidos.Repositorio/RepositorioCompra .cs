using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioCompra
    {
        private Contexto contexto;

        public RepositorioCompra()
        {
            contexto = new Contexto();
        }

        public void Adicione(Compra compra )
        {
            var CompraOriginal = contexto.Set<Compra>().Find(compra.Codigo);
            compra = CompraOriginal;
            contexto.Set<Compra>().Add(compra);
            contexto.SaveChanges();
        }

        public void Atualize(Compra compra)
        {
            var CompraOriginal = contexto.Set<Compra>().Find(compra.Codigo);
            var original = contexto.Set<Compra>().Find(compra.Codigo);
            original = CompraOriginal;
            contexto.Entry(original).CurrentValues.SetValues(compra);
            contexto.SaveChanges();
        }

        public List<Compra> Liste()
        {
            contexto = new Contexto();
            var lista = contexto.Set<Compra>().ToList();
            return lista;
        }

        public void Excluir(Compra compra)
        {
            var original = contexto.Set<Compra>().Find(compra.Codigo);
            contexto.Set<Compra>().Remove(original);
            contexto.SaveChanges();
        }


    }
}
