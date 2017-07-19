﻿using ControladorDePedidos.Model;
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
    /// Lógica interna para FormCadastroDeCompra.xaml
    /// </summary>
    public partial class FormCadastroDeCompra : Window
    {
        RepositorioCompra repositorio;
        RepositorioItemDaCompra repositorioItemDaCompra;
        public int Codigo { get; set; }
        public FormCadastroDeCompra()
        {
            InitializeComponent();
            repositorioItemDaCompra = new RepositorioItemDaCompra();
            repositorio = new RepositorioCompra();
            var compra = new Compra();
            compra.DataDeCadastro = DateTime.Now;
            compra.Status = eStatusDaCompra.NOVA;
            repositorio.Adicione(compra);
            Codigo = compra.Codigo;
            this.DataContext = compra;
        }

        public FormCadastroDeCompra(Compra compra)
        {
            InitializeComponent();
            repositorioItemDaCompra = new RepositorioItemDaCompra();
            repositorio = new RepositorioCompra();
            this.DataContext = compra;
            Codigo = compra.Codigo;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var compra = (Compra)this.DataContext;
         
                //Editando Cadastro
                repositorio.Atualize(compra);
            
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnObterRecomendacao_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            var formulario = new FormBuscaDeProduto();
            formulario.ShowDialog();
            if(formulario.ProdutoSelecionado != null)
            {
                var itemDaCompra = new ItemDaCompra
                {
                    Compra = new Compra { Codigo = this.Codigo },
                    Produto = formulario.ProdutoSelecionado,
                    Quantidade = formulario.Quantidade,
                    Valor = formulario.ProdutoSelecionado.ValorDeCompra
                };
                repositorioItemDaCompra.Adicione(itemDaCompra);
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExcluir_Click_1(object sender, RoutedEventArgs e)
        {

        }

    
    }
}
