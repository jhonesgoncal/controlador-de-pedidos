using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioVenda
    {
        private Contexto contexto;

        public RepositorioVenda()
        {
            contexto = new Contexto();
        }

        public void Adicione(Venda venda )
        {
            var VendaOriginal = contexto.Set<Venda>().Find(venda.Codigo);
            if (VendaOriginal != null)
                throw new ApplicationException("Já existe uma venda com esse código");
            contexto.Set<Venda>().Add(venda);
            contexto.SaveChanges();
        }

        public void Atualize(Venda venda)
        {
            var original = contexto.Set<Venda>().Find(venda.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(venda);
            contexto.SaveChanges();
        }

        public List<Venda> Liste()
        {
            contexto = new Contexto();
            var lista = contexto.Set<Venda>().ToList();
            return lista;
        }

        public void Excluir(Venda venda)
        {
            var original = contexto.Set<Venda>().Find(venda.Codigo);
            contexto.Set<Venda>().Remove(original);
            contexto.SaveChanges();
        }


    }
}
