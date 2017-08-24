using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;

namespace ControladorDePedidos.WPF
{
    public partial class FormFinanceiro : Window
    {
        RepositorioFinanceiro repositorio;
        Financeiro financeiro = new Financeiro();
        public FormFinanceiro()
        {
            repositorio = new RepositorioFinanceiro();
            InitializeComponent();
        }

        private void FormFinanceiro_OnLoaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnDividas_Click(object sender, RoutedEventArgs e)
        {
            var formDividas = new FormDividas();
            formDividas.Show();
        }

        private void btnCompras_Click(object sender, RoutedEventArgs e)
        {
            var formCompras = new FormCompras();
            formCompras.Show();
        }

        private void btnVendas_Click(object sender, RoutedEventArgs e)
        {
            var formVendas = new FormVendas();
            formVendas.Show();
        }


        private void CarregueElementosDoBancoDeDados()
        {
            txtCompras.DataContext = financeiro.TotalCompras;
            txtDividas.DataContext = financeiro.TotalDividas;
            txtVendas.DataContext = financeiro.TotalVendas;
            txtSaldo.DataContext = financeiro.Saldo;
        }

        private void btnDeposito_Click(object sender, RoutedEventArgs e)
        {
            financeiro.Saldo = decimal.Parse(txtDeposito.Text);
            repositorio.Adicione(financeiro);
        }
    }
}
