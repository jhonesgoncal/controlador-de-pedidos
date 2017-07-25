using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
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

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Lógica interna para FormVendas.xaml
    /// </summary>
    public partial class FormVendas : Window
    {
        private RepositorioVenda repositorio;
        public FormVendas()
        {
            repositorio = new RepositorioVenda();
            InitializeComponent();

        }

        private void FormVendas_OnLoaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new FormVendas();
            formMarca.Show();
        }
        private void CarregueElementosDoBancoDeDados()
        {
            lstVendas.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeVenda = new FormCadastroDeVenda();
            formCadastroDeVenda.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstVendas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (Venda)lstVendas.SelectedItem;
            var formCadastroDeVenda = new FormCadastroDeVenda(itemSelecionado);
            formCadastroDeVenda.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstVendas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (Venda)lstVendas.SelectedItem;
            repositorio.Excluir(itemSelecionado);
            CarregueElementosDoBancoDeDados();

        }

        private void btnNovo_Click_1(object sender, RoutedEventArgs e)
        {

        }

       

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            //Pega os itens da venda e efetiva
            if (lstVendas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }
            
            var venda = (Venda)lstVendas.SelectedItem;
            if(venda.Status != eStatusDaVenda.NOVA)
            {
                MessageBox.Show("Essa venda já foi efetivada!");
                return;
            }
            if(venda.ItensDaVenda.Count == 0)
            {
                MessageBox.Show("Nenhum item a ser vendado nessa solicitação de venda.");
                return;
            }
            var itensDaVenda = obtenhaListaDeItensDaVenda(venda);
           
            //Salva no banco
            venda.Status = eStatusDaVenda.EFETIVADA;
            venda.DataDeEfetivacao = DateTime.Now;
            repositorio.Atualize(venda);
            CarregueElementosDoBancoDeDados();

        }
        private static List<ItemDaVenda> obtenhaListaDeItensDaVenda(Venda venda)
        {
            var repositorioItemDaVenda = new RepositorioItemDaVenda();
            var itensDaVenda = repositorioItemDaVenda.Liste(venda.Codigo);
            return itensDaVenda;
        }
    }
}
