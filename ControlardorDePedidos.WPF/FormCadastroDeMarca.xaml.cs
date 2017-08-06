using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;

namespace ControladorDePedidos.WPF
{
    public partial class FormCadastroDeMarca : Window
    {
        public int Codigo { get; set; }
        public FormCadastroDeMarca()
        {
            InitializeComponent();
        }

        public FormCadastroDeMarca(Marca marca)
        {
            InitializeComponent();
            Codigo = marca.Codigo;
            txtNome.Text = marca.Nome;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = Codigo;
            var nome = txtNome.Text;
            var repositorio = new RepositorioMarca();
            if (codigo == 0)
            {
                //Novo Cadastro
                var marca = new Marca
                { 
                    Nome = nome
                };

                repositorio.Adicione(marca);
            }
            else
            {
                //Editando Cadastro
                var marca = new Marca
                {
                    Codigo = codigo,
                    Nome = nome
                };

                repositorio.Atualize(marca);
            }

            this.Close();
        }
    }
}
