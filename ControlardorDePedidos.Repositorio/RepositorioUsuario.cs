using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlardorDePedidos.Model;

namespace ControlardorDePedidos.Repositorio
{
    public class RepositorioUsuario
    {
        private Contexto contexto;

        public RepositorioUsuario()
        {
            contexto = new Contexto();
        }

        public void Adicione(Usuario usuario )
        {
            contexto.Set<Usuario>().Add(usuario);
            contexto.SaveChanges();
        }

        public void Atualize(Usuario usuario)
        {
            var original = contexto.Set<Usuario>().Find(usuario.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(usuario);
            contexto.SaveChanges();
        }

        public List<Usuario> Liste()
        {
            contexto = new Contexto();
            var lista = contexto.Set<Usuario>().ToList();
            return lista;
        }

        public void Excluir(Usuario usuario)
        {
            var original = contexto.Set<Usuario>().Find(usuario.Codigo);
            contexto.Set<Usuario>().Remove(original);
            contexto.SaveChanges();
        }


    }
}
