using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;

namespace ControladorDePedidos.WPF
{
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



                if (txtSenha.Password != txtConfirmaSenha.Password)
                {
                    MessageBox.Show("As senhas devem ser iguais");
                    return;
                }

                if (string.IsNullOrEmpty(txtConfirmaSenha.Password) || string.IsNullOrEmpty(txtSenha.Password))
                {
                    MessageBox.Show("As senhas devem ser informada");
                    return;
                }

                
            }

           if(usuario.Codigo == 0 || !string.IsNullOrEmpty(txtSenha.Password))
            {
                usuario.Senha = txtSenha.Password;
            }

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
