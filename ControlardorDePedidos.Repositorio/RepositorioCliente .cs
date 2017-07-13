using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioCliente
    {
        private Contexto contexto;

        public RepositorioCliente()
        {
            contexto = new Contexto();
        }

        public void Adicione(Cliente cliente )
        {
            contexto.Set<Cliente>().Add(cliente);
            contexto.SaveChanges();
        }

        public void Atualize(Cliente cliente)
        {
            var original = contexto.Set<Cliente>().Find(cliente.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(cliente);
            contexto.SaveChanges();
        }

        public List<Cliente> Liste()
        {
            contexto = new Contexto();
            var lista = contexto.Set<Cliente>().ToList();
            return lista;
        }

        public void Excluir(Cliente cliente)
        {
            var original = contexto.Set<Cliente>().Find(cliente.Codigo);
            contexto.Set<Cliente>().Remove(original);
            contexto.SaveChanges();
        }


    }
}
