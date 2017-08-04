using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlardorDePedidos.Repositorio
{
    public class RepositorioGenerico<T> where T : ClasseBase
    {
        protected Contexto contexto;

        public RepositorioGenerico()
        {
            contexto = new Contexto();
        }

        public virtual void Adicione(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();
        }
        public virtual  void Atualize(T item)
        {
            var original = contexto.Set<T>().Find(item.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(item);
            contexto.SaveChanges();
        }

        public List<T> Liste()
        {
            contexto = new Contexto();
            var lista = contexto.Set<T>().ToList();
            return lista;
        }

        public void Excluir(T item)
        {
            var original = contexto.Set<T>().Find(item.Codigo);
            contexto.Set<T>().Remove(original);
            contexto.SaveChanges();
        }

    }
}
