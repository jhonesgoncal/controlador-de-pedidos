using ControladorDePedidos.Model;
using System.Collections.Generic;
using System.Linq;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioCliente : RepositorioGenerico<Cliente>
    {
        public List<Cliente> Buscar(string termoDaBusca)
        {
            contexto = new Contexto();
            var lista = contexto.Set<Cliente>().Where(x => x.Nome.Contains(termoDaBusca)).ToList();
            return lista;
        }
    }
}
