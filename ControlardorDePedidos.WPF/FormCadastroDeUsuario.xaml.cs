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
using ControlardorDePedidos.Model;
using ControlardorDePedidos.Repositorio;

namespace ControlardorDePedidos.WPF
{
    /// <summary>
    /// Lógica interna para FormCadastroDeUsuario.xaml
    /// </summary>
    public partial class FormCadastroDeUsuario : Window
    {
        public FormCadastroDeUsuario()
        {
            InitializeComponent();
            this.DataContext = new Usuario();
        }

        public FormCadastroDeUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.DataContext = usuario;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var usuario = (Usuario)this.DataContext;
            var repositorio = new RepositorioUsuario();
            if (usuario.Codigo == 0)
            {
                //Novo Cadastro
                repositorio.Adicione(usuario);
            }
            else
            {
                //Editando Cadastro
                repositorio.Atualize(usuario);
            }

            this.Close();
        }
    }
}
