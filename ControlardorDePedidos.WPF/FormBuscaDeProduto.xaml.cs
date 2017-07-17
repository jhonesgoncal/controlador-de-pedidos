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
    /// Lógica interna para FormBuscaDeProduto.xaml
    /// </summary>
    public partial class FormBuscaDeProduto : Window
    {
        RepositorioProduto repositorio;
        public FormBuscaDeProduto()
        {
            InitializeComponent();
            repositorio = new RepositorioProduto();
        }

        private void txtTermoDaBusca_KeyDown(object sender, KeyEventArgs e)
        {
            var listaDeProdutos = repositorio.Buscar(txtTermoDaBusca.Text);
            lstProdutos.DataContext = listaDeProdutos;
        }
        private void CarregueElementosDoBancoDeDados()
        {
            lstProdutos.DataContext = repositorio.Liste();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }
    }
}
