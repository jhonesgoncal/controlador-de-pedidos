using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using ControladorDePedidos.WPF;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione o Usuário");
                return;
            }
            var senha = txtSenha.Password;
            var usuario = (Usuario)cmbUsuarios.SelectedItem;

            var repositorioUsuario = new RepositorioUsuario();
            if (repositorioUsuario.ValideAcesso(usuario.Codigo, senha))
            {
                var listaDeUsuarios = (List<Usuario>)cmbUsuarios.DataContext;
                var quantidade = listaDeUsuarios.Where(x => x.Administrador).Count();
                if (quantidade == 0)
                {
                    MessageBox.Show("Não existe administrador cadastrado no sistema, logo este usuario terá permissões de administrador.");
                    usuario.Administrador = true;
                }
                    this.Hide();
                    var formPrincipal = new MainWindow(usuario);
                    formPrincipal.ShowDialog();
                    this.Close();
            }
            else
            {
                MessageBox.Show("Dados incorretos");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            var respositorioUsuario = new RepositorioUsuario();
            var listaDeUsuarios = respositorioUsuario.Liste();
            if(listaDeUsuarios.Count == 0)
            {
                var usuario = new Usuario
                {
                    Administrador = true
                };
               
                this.Hide();
                var formPrincipal = new MainWindow(usuario);
                formPrincipal.ShowDialog();
                this.Close();
            }
            cmbUsuarios.DataContext = listaDeUsuarios;
        }

        private void cmbUsuarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
