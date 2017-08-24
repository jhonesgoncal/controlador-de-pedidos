using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;

namespace ControladorDePedidos.WPF
{
    public partial class FormDividas : Window
    {
        RepositorioDivida repositorio;
        public FormDividas()
        {
            repositorio = new RepositorioDivida();
            InitializeComponent();
        }

        private void FormDivida_OnLoaded(object sender, RoutedEventArgs e)
        {
          CarregueElementosDoBancoDeDados();

        }

        private void CarregueElementosDoBancoDeDados()
        {
            lstDividas.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDivida = new FormCadastroDeDivida();
            formCadastroDivida.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            
            if (lstDividas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }else
            {
                var itemSelecionado = (Divida)lstDividas.SelectedItem;
                var formCadastroDividae = new FormCadastroDeDivida(itemSelecionado);
                formCadastroDividae.ShowDialog();
                CarregueElementosDoBancoDeDados();
            }
          
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
       
            if (lstDividas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Divida)lstDividas.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElementosDoBancoDeDados();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnPagar_Click(object sender, RoutedEventArgs e)
        {
            var divida = (Divida)lstDividas.SelectedItem;
            if (lstDividas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }
            divida.Situacao = eStatusDaDivida.PAGA;
            repositorio.Atualize(divida);
            CarregueElementosDoBancoDeDados();
        }
    }
}
