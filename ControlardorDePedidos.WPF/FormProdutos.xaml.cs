using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Lógica interna para FormProdutos.xaml
    /// </summary>
    public partial class FormProdutos : Window
    {
        private RepositorioProduto repositorio;
        public FormProdutos()
        {
            repositorio = new RepositorioProduto();
            InitializeComponent();
           
        }

        private void FormProdutos_OnLoaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new FormMarcas();
            formMarca.Show();
        }
        private void CarregueElementosDoBancoDeDados()
        {
            lstProdutos.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeProduto = new FormCadastroDeProduto();
            formCadastroDeProduto.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (Produto)lstProdutos.SelectedItem;
            var formCadastroDeProduto = new FormCadastroDeProduto(itemSelecionado);
            formCadastroDeProduto.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (Produto)lstProdutos.SelectedItem;
            repositorio.Excluir(itemSelecionado);
            CarregueElementosDoBancoDeDados();

        }
    }
}
