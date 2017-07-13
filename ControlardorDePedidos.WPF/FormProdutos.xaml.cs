using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class ConversorDeEstoque : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var produto = value as Produto;
            if(produto.QuantidadeEmEstoque < produto.QuantidadeMinimaEmEstoque)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
            {
                return new SolidColorBrush(Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
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

        private void btnNovo_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
