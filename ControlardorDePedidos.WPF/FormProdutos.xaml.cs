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
    /// Lógica interna para FormProdutos.xaml
    /// </summary>
    public partial class FormProdutos : Window
    {
        public FormProdutos()
        {
            InitializeComponent();
        }

        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new FormMarcas();
            formMarca.Show();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeProduto = new FormCadastroDeProduto();
            formCadastroDeProduto.ShowDialog();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeProduto = new FormCadastroDeProduto();
            formCadastroDeProduto.ShowDialog();
        }
    }
}
