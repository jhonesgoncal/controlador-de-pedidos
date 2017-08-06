using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;

namespace ControladorDePedidos.WPF
{
    public partial class FormCadastroDeProduto : Window
    {
        private RepositorioMarca repositorioMarca;
        private RepositorioFornecedor repositorioFornecedor;
        private RepositorioProduto repositorioProduto;
        public FormCadastroDeProduto()
        {
            repositorioMarca = new RepositorioMarca();
            repositorioFornecedor = new RepositorioFornecedor();
            repositorioProduto = new RepositorioProduto();
            InitializeComponent();
            this.DataContext = new Produto();
        }

        public FormCadastroDeProduto(Produto produto)
        {
            repositorioMarca = new RepositorioMarca();
            repositorioFornecedor = new RepositorioFornecedor();
            repositorioProduto = new RepositorioProduto();
            InitializeComponent();
            this.DataContext = produto;
            cmbMarcas.SelectedValue = produto.Marca.Codigo;
            cmbFornecedores.SelectedValue = produto.Fornecedor.Codigo;
        }

        private void FormCadastroDeProduto_OnLoaded(object sender, RoutedEventArgs e)
        {
            var marcas = repositorioMarca.Liste();
            cmbMarcas.DataContext = marcas;

            var fornecedor = repositorioFornecedor.Liste();
            cmbFornecedores.DataContext = fornecedor;


        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var produto = (Produto)this.DataContext;
            if (cmbMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma Marca");
            }
            else
            {
                produto.Marca = (Marca) cmbMarcas.SelectedItem;
            }

            if (cmbFornecedores.SelectedItem == null)
            {
                MessageBox.Show("Selecione um Fornecedor");
            }
            else
            {
                produto.Fornecedor = (Fornecedor)cmbFornecedores.SelectedItem;
            }


            if (produto.Codigo == 0)
            {
                //cadastro
                repositorioProduto.Adicione(produto);
            }
            else
            {
                //atualizacao
                repositorioProduto.Atualize(produto);
            }

            this.Close();
        }
    }
}
