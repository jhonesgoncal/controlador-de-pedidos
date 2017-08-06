using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    public partial class FormCadastroDeCompra : Window
    {
        RepositorioCompra repositorio;
        RepositorioItemDaCompra repositorioItemDaCompra;
        RepositorioProduto repositorioProduto;
        public int Codigo { get; set; }
        public Compra Compra { get; set; }

        public FormCadastroDeCompra()
        {
            InitializeComponent();
            InicializeOperacoes();
            var compra = new Compra();
            compra.DataDeCadastro = DateTime.Now;
            compra.Status = eStatusDaCompra.NOVA;
            repositorio.Adicione(compra);
            Codigo = compra.Codigo;
            Compra = compra;
            lstProdutos.DataContext = compra.ItensDaCompra;
        }

        private void InicializeOperacoes()
        {
            repositorioItemDaCompra = new RepositorioItemDaCompra();
            repositorio = new RepositorioCompra();
            repositorioProduto = new RepositorioProduto();
        }

        public FormCadastroDeCompra(Compra compra)
        {
            InitializeComponent();
            InicializeOperacoes();
            lstProdutos.DataContext = compra.ItensDaCompra;
            Codigo = compra.Codigo;
            Compra = compra;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var compra = (Compra)this.DataContext;
            if(compra != null)
            {
                //Editando Cadastro
                repositorio.Atualize(compra);
            }
         
            this.Close();
        }

        private void btnObterRecomendacao_Click(object sender, RoutedEventArgs e)
        {
            if(Compra.Status != eStatusDaCompra.NOVA)
            {
                MessageBox.Show("Não é possivel adicionar produtos a uma compra efetivada!");
                return;
            }
            var listaEstoqueBaixo = repositorioProduto.ObtenhaProdutosComEstoqueBaixo();
            foreach(var produto in listaEstoqueBaixo)
            {
                var itemDaCompra = new ItemDaCompra
                {
                    Compra = new Compra { Codigo = this.Codigo },
                    Produto = produto,
                    Quantidade = produto.QuantidadeDesejavelEmEstoque - produto.QuantidadeEmEstoque,
                    Valor = produto.ValorDeCompra
                };
                repositorioItemDaCompra.Adicione(itemDaCompra);  
            }
            lstProdutos.DataContext = repositorioItemDaCompra.Liste(Codigo);
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (Compra.Status != eStatusDaCompra.NOVA)
            {
                MessageBox.Show("Não é possivel adicionar produtos a uma compra efetivada!");
                return;
            }
            var formulario = new FormBuscaDeProduto();
            formulario.ShowDialog();
            if(formulario.ProdutoSelecionado != null)
            {
                var itemDaCompra = new ItemDaCompra
                {
                    Compra = new Compra { Codigo = this.Codigo },
                    Produto = formulario.ProdutoSelecionado,
                    Quantidade = formulario.Quantidade,
                    Valor = formulario.ProdutoSelecionado.ValorDeCompra
                };
                repositorioItemDaCompra.Adicione(itemDaCompra);
                lstProdutos.DataContext = repositorioItemDaCompra.Liste(Codigo);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (ItemDaCompra)lstProdutos.SelectedItem;
            repositorioItemDaCompra.Excluir(itemSelecionado);
            lstProdutos.DataContext = repositorioItemDaCompra.Liste(Codigo);
        }

       

    
    }
}
