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
using ControlardorDePedidos.Repositorio;

namespace ControlardorDePedidos.WPF
{
    /// <summary>
    /// Lógica interna para FormCadastroDeMarca.xaml
    /// </summary>
    public partial class FormCadastroDeMarca : Window
    {
        public FormCadastroDeMarca()
        {
            InitializeComponent();
        }

        public FormCadastroDeMarca(Marca marca)
        {
            InitializeComponent();
            txtCodigo.Text = marca.Codigo.ToString();
            txtNome.Text = marca.Nome;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = txtCodigo.Text;
            var nome = txtNome.Text;
            var repositorio = new RepositorioMarca();
            if (codigo == "")
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
                    Codigo = int.Parse(codigo),
                    Nome = nome
                };

                repositorio.Atualize(marca);
            }

            this.Close();
        }
    }
}
