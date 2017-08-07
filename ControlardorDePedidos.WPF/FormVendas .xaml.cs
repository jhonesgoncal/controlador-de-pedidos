using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    public partial class FormVendas : Window
    {
        public Cliente Cliente { get; set; }
        private RepositorioVenda repositorio;
        public FormVendas()
        {
            repositorio = new RepositorioVenda();
            InitializeComponent();

        }

        public FormVendas(Cliente cliente)
        {
            InitializeComponent();
            this.Cliente = cliente;
            this.Title = "Pedidos do cliente " + cliente.Nome;
            repositorio = new RepositorioVenda();
            

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
            if(this.Cliente == null)
            {
                lstVendas.DataContext = repositorio.Liste();
            }
            else
            {
                lstVendas.DataContext = repositorio.ListePorCliente(Cliente.Codigo);
            }
            
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
            if(venda.Cliente == null)
            {
                MessageBox.Show("Precisar existir um cliente para efetivar a venda.");
                return;
            }
            var itensDaVenda = obtenhaListaDeItensDaVenda(venda);
            var repositorioDeProduto = new RepositorioProduto();
            foreach (var item in itensDaVenda)
            {
                var produtoDaVenda = item.Produto;
                var produtoBanco = repositorioDeProduto.Consultar(produtoDaVenda.Codigo);
                produtoBanco.QuantidadeEmEstoque -= item.Quantidade;
                repositorioDeProduto.Atualize(produtoBanco);
            }

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
