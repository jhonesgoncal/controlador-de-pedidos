using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Drawing;
using System.Globalization;

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
            repositorio.Atualize(financeiro);
            txtCompras.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", financeiro.TotalCompras.ToString());
            txtDividas.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", financeiro.TotalDividas.ToString());
            txtVendas.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", financeiro.TotalVendas.ToString());
            txtSaldo.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", financeiro.Saldo.ToString());
        }

        private void btnDeposito_Click(object sender, RoutedEventArgs e)
        {
            financeiro.Saldo = decimal.Parse(txtDeposito.Text);
            repositorio.Adicione(financeiro);
            CarregueElementosDoBancoDeDados();
        }
    }
}
