using System.Collections.Generic;
using System.Linq;
using ControladorDePedidos.Model;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioProduto : RepositorioGenerico<Produto>
    {
       

        public override void Adicione(Produto produto )
        {
            var MarcaOriginal = contexto.Set<Marca>().Find(produto.Marca.Codigo);
            var FornecedorOriginal = contexto.Set<Fornecedor>().Find(produto.Fornecedor.Codigo);
            produto.Marca = MarcaOriginal;
            produto.Fornecedor = FornecedorOriginal;
            base.Adicione(produto);
        }


        public override void Atualize(Produto produto)
        {
            var MarcaOriginal = contexto.Set<Marca>().Find(produto.Marca.Codigo);
            var FornecedorOriginal = contexto.Set<Fornecedor>().Find(produto.Fornecedor.Codigo);
            var original = contexto.Set<Produto>().Find(produto.Codigo);
            original.Marca = MarcaOriginal;
            original.Fornecedor = FornecedorOriginal;
            contexto.Entry(original).CurrentValues.SetValues(produto);
            contexto.SaveChanges();
        }

        public List<Produto> Buscar(string termoDaBusca)
        {
            contexto = new Contexto();
            var lista = contexto.Set<Produto>().Where(x => x.Nome.Contains(termoDaBusca)).ToList();
            return lista;
        }

        public Produto Consultar(int codigo)
        {
            contexto = new Contexto();
            return contexto.Set<Produto>().FirstOrDefault(x => x.Codigo == codigo);
        }

        public List<Produto> ObtenhaProdutosComEstoqueBaixo()
        {
            contexto = new Contexto();
            var lista = contexto.Set<Produto>().Where(x => x.QuantidadeEmEstoque < x.QuantidadeDesejavelEmEstoque).ToList();
            return lista;
        }
    }
}
