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
    /// Lógica interna para FormClientes.xaml
    /// </summary>
    public partial class FormClientes : Window
    {
        RepositorioCliente repositorio;
        public FormClientes()
        {
            repositorio = new RepositorioCliente();
            InitializeComponent();
        }

        private void FormClientes_OnLoaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();

        }

        private void CarregueElementosDoBancoDeDados()
        {
            lstClientes.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroCliente = new FormCadastroDeCliente();
            formCadastroCliente.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Cliente)lstClientes.SelectedItem;
                var formCadastroCliente = new FormCadastroDeCliente(itemSelecionado);
                formCadastroCliente.ShowDialog();
                CarregueElementosDoBancoDeDados();
            }

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

            if (lstClientes.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Cliente)lstClientes.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElementosDoBancoDeDados();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

    }
}
