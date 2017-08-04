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
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Teste commit para FormCadastroDeFornecedor.xaml
    /// </summary>
    public partial class FormCadastroDeFornecedor : Window
    {
        public FormCadastroDeFornecedor()
        {
            InitializeComponent();
        }

        public FormCadastroDeFornecedor(Fornecedor Fornecedor)
        {
            InitializeComponent();
            txtCodigo.Text = Fornecedor.Codigo.ToString();
            txtNome.Text = Fornecedor.Nome;
            txtEmail.Text = Fornecedor.Email;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = txtCodigo.Text;
            var nome = txtNome.Text;
            var email = txtEmail.Text;
            var repositorio = new RepositorioFornecedor();
            if (codigo == "")
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
                    Codigo = int.Parse(codigo),
                    Nome = nome,
                    Email = email
                };

                repositorio.Atualize(Fornecedor);
            }

            this.Close();
        }
    }
}
