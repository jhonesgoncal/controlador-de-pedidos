using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
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

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Lógica interna para FormCompras.xaml
    /// </summary>
    public partial class FormCompras : Window
    {
        private RepositorioCompra repositorio;
        public FormCompras()
        {
            repositorio = new RepositorioCompra();
            InitializeComponent();

        }

        private void FormCompras_OnLoaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new FormCompras();
            formMarca.Show();
        }
        private void CarregueElementosDoBancoDeDados()
        {
            lstCompras.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeCompra = new FormCadastroDeCompra();
            formCadastroDeCompra.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (Compra)lstCompras.SelectedItem;
            var formCadastroDeCompra = new FormCadastroDeCompra(itemSelecionado);
            formCadastroDeCompra.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (Compra)lstCompras.SelectedItem;
            repositorio.Excluir(itemSelecionado);
            CarregueElementosDoBancoDeDados();

        }

        private void btnNovo_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
