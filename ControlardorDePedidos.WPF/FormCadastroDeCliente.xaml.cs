using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    public partial class FormCadastroDeCliente : Window
    {
        public FormCadastroDeCliente()
        {
            InitializeComponent();
            this.DataContext = new Cliente();
        }

        public FormCadastroDeCliente(Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = cliente;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (Cliente)this.DataContext;
            var repositorio = new RepositorioCliente();
            if (cliente.Codigo == 0)
            {
                //Novo Cadastro
                repositorio.Adicione(cliente);
            }
            else
            {
                //Editando Cadastro
                repositorio.Atualize(cliente);
            }

            this.Close();
        }
    }
}
