using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    public partial class FormCadastroDeVenda : Window
    {
        RepositorioVenda repositorio;
        RepositorioItemDaVenda repositorioItemDaVenda;
        RepositorioProduto repositorioProduto;
        public int Codigo { get; set; }
        public Venda Venda { get; set; }

        public FormCadastroDeVenda()
        {
            InitializeComponent();
            InicializeOperacoes();
            var venda = new Venda();
            venda.DataDeCadastro = DateTime.Now;
            venda.Status = eStatusDaVenda.NOVA;
            repositorio.Adicione(venda);
            Codigo = venda.Codigo;
            Venda = venda;
            lstProdutos.DataContext = venda.ItensDaVenda;
        }

        private void InicializeOperacoes()
        {
            repositorioItemDaVenda = new RepositorioItemDaVenda();
            repositorio = new RepositorioVenda();
            repositorioProduto = new RepositorioProduto();
        }

        public FormCadastroDeVenda(Venda venda)
        {
            InitializeComponent();
            InicializeOperacoes();
            lstProdutos.DataContext = venda.ItensDaVenda;
            Codigo = venda.Codigo;
            Venda = venda;
            if(Venda.Cliente != null)
            {
                txtCliente.Text = Venda.Cliente.Nome;
            }
            
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var venda = (Venda)this.DataContext;
            if(venda != null)
            {
                //Editando Cadastro
                repositorio.Atualize(venda);
            }
         
            this.Close();
        }

        private void btnObterRecomendacao_Click(object sender, RoutedEventArgs e)
        {
            if(Venda.Status != eStatusDaVenda.NOVA)
            {
                MessageBox.Show("Não é possivel adicionar produtos a uma venda efetivada!");
                return;
            }
            var listaEstoqueBaixo = repositorioProduto.ObtenhaProdutosComEstoqueBaixo();
            foreach(var produto in listaEstoqueBaixo)
            {
                var itemDaVenda = new ItemDaVenda
                {
                    Venda = new Venda { Codigo = this.Codigo },
                    Produto = produto,
                    Quantidade = produto.QuantidadeDesejavelEmEstoque - produto.QuantidadeEmEstoque,
                    Valor = produto.ValorDeVenda
                };
                repositorioItemDaVenda.Adicione(itemDaVenda);  
            }
            lstProdutos.DataContext = repositorioItemDaVenda.Liste(Codigo);
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (Venda.Status != eStatusDaVenda.NOVA)
            {
                MessageBox.Show("Não é possivel adicionar produtos a uma venda efetivada!");
                return;
            }
            var formulario = new FormBuscaDeProduto();
            formulario.ShowDialog();
            if(formulario.ProdutoSelecionado != null)
            {
                var itemDaVenda = new ItemDaVenda
                {
                    Venda = new Venda { Codigo = this.Codigo },
                    Produto = formulario.ProdutoSelecionado,
                    Quantidade = formulario.Quantidade,
                    Valor = formulario.ProdutoSelecionado.ValorDeVenda
                };
                repositorioItemDaVenda.Adicione(itemDaVenda);
                lstProdutos.DataContext = repositorioItemDaVenda.Liste(Codigo);
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

            var itemSelecionado = (ItemDaVenda)lstProdutos.SelectedItem;
            repositorioItemDaVenda.Excluir(itemSelecionado);
            lstProdutos.DataContext = repositorioItemDaVenda.Liste(Codigo);
        }

        private void btnCliente_Click(object sender, RoutedEventArgs e)
        {
            if (Venda.Status != eStatusDaVenda.NOVA)
            {
                MessageBox.Show("Não é possivel selecionar um cliente para uma venda efetivada!");
                return;
            }
            var buscaDecliente = new FormBuscaDeCliente();
            buscaDecliente.ShowDialog();
            Venda.Cliente = buscaDecliente.ClienteSelecionado;
            if (Venda.Cliente != null)
            {
                txtCliente.Text = Venda.Cliente.Nome;
            }
            repositorio.Atualize(Venda);
        }
    }
}
