using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;

namespace ControladorDePedidos.WPF
{
    public partial class FormCadastroDeFornecedor : Window
    {
        public int Codigo { get; set; }
        public FormCadastroDeFornecedor()
        {
            InitializeComponent();
        }

        public FormCadastroDeFornecedor(Fornecedor Fornecedor)
        {
            InitializeComponent();
            Codigo = Fornecedor.Codigo;
            txtNome.Text = Fornecedor.Nome;
            txtEmail.Text = Fornecedor.Email;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = Codigo;
            var nome = txtNome.Text;
            var email = txtEmail.Text;
            var repositorio = new RepositorioFornecedor();
            if (codigo == 0)
            {
                //Novo Cadastro
                var Fornecedor = new Fornecedor
                { 
                    Nome = nome,
                    Email = email
                };

                repositorio.Adicione(Fornecedor);
            }
            else
            {
                //Editando Cadastro
                var Fornecedor = new Fornecedor
                {
                    Codigo = codigo,
                    Nome = nome,
                    Email = email
                };

                repositorio.Atualize(Fornecedor);
            }

            this.Close();
        }
    }
}
