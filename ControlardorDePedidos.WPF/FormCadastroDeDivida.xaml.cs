using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;

namespace ControladorDePedidos.WPF
{
    public partial class FormCadastroDeDivida : Window
    {
        public int Codigo { get; set; }
        public FormCadastroDeDivida()
        {
            InitializeComponent();
        }

        public FormCadastroDeDivida(Divida divida)
        {
            InitializeComponent();
            Codigo = divida.Codigo;
            txtNome.Text = divida.Nome;
            txtValor.Text = divida.ValorDaDivida.ToString();
            txtData.SelectedDate = divida.DataDeVencimento;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var codigo = Codigo;
            var nome = txtNome.Text;
            var valor = decimal.Parse(txtValor.Text);
            DateTime data = txtData.SelectedDate.Value.Date;
            
            var repositorio = new RepositorioDivida();
            if (codigo == 0)
            {
                //Novo Cadastro
                var divida = new Divida
                { 
                    Nome = nome,
                    ValorDaDivida = valor,
                    DataDeVencimento = data

                };
                if(divida.DataDeVencimento < DateTime.Now)
                {
                    divida.Situacao = eStatusDaDivida.ATRASADA;
                }
                else
                {
                    divida.Situacao = eStatusDaDivida.PENDENTE;
                }

                repositorio.Adicione(divida);
            }
            else
            {
                //Editando Cadastro
                var divida = new Divida
                {
                    Codigo = codigo,
                    Nome = nome,
                    ValorDaDivida = valor,
                    DataDeVencimento = data
                };

                repositorio.Atualize(divida);
            }

            this.Close();
        }
    }
}
