using ControladorDePedidos.Model;
using System.Linq;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioDivida : RepositorioGenerico<Divida>
    {
        public decimal TotalDeDivida()
        {
            return contexto.Set<Divida>().Sum(x => x.ValorDaDivida);
        }

    }
}
