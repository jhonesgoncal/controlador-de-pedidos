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
using ControlardorDePedidos.Repositorio;

namespace ControlardorDePedidos.WPF
{
    /// <summary>
    /// Lógica interna para FormCadastroDeProduto.xaml
    /// </summary>
    public partial class FormCadastroDeProduto : Window
    {
        private RepositorioMarca repositorio;
        public FormCadastroDeProduto()
        {
            repositorio = new RepositorioMarca();
            InitializeComponent();
        }

        private void FormCadastroDeProduto_OnLoaded(object sender, RoutedEventArgs e)
        {
            var marcas = repositorio.Liste();
            cmbMarcas.DataContext = marcas;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
