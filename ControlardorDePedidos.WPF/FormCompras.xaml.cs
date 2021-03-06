﻿using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using static ControladorDePedidos.WPF.Utilitarios;
namespace ControladorDePedidos.WPF
{
    public partial class FormCompras : Window
    {
        private RepositorioCompra repositorio;
        public FormCompras()
        {
            repositorio = new RepositorioCompra();
            InitializeComponent();

        }

        private void FormCompras_OnLoaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }

        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new FormCompras();
            formMarca.Show();
        }
        private void CarregueElementosDoBancoDeDados()
        {
            lstCompras.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeCompra = new FormCadastroDeCompra();
            formCadastroDeCompra.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (Compra)lstCompras.SelectedItem;
            var formCadastroDeCompra = new FormCadastroDeCompra(itemSelecionado);
            formCadastroDeCompra.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var itemSelecionado = (Compra)lstCompras.SelectedItem;
            repositorio.Excluir(itemSelecionado);
            CarregueElementosDoBancoDeDados();

        }

        private void btnCompraRecebida_Click(object sender, RoutedEventArgs e)
        {
            //Adicionar no estoque
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }

            var compra = (Compra)lstCompras.SelectedItem;
            if (compra.Status != eStatusDaCompra.EFETIVADA)
            {
                MessageBox.Show("Essa compra precisa estar efetivada!");
                return;
            }
            if (compra.ItensDaCompra.Count == 0)
            {
                MessageBox.Show("Nenhum item a ser comprado nessa solicitação de compra.");
                return;
            }
            //adicionar no estoque
            var itensDaCompra = obtenhaListaDeItensDaCompra(compra);
            var repositorioDeProduto = new RepositorioProduto();
            foreach(var item in itensDaCompra)
            {
                var produtoDacompra = item.Produto;
                var produtoBanco = repositorioDeProduto.Consultar(produtoDacompra.Codigo);
                produtoBanco.QuantidadeEmEstoque += item.Quantidade;
                repositorioDeProduto.Atualize(produtoBanco);
            }

            //ataulizar banco de daos
            compra.Status = eStatusDaCompra.RECEBIDA;
            compra.DataDoRecebimento = DateTime.Now;
            repositorio.Atualize(compra);
            CarregueElementosDoBancoDeDados();
        }

       

        private void btnComprar_Click(object sender, RoutedEventArgs e)
        {
            //Pega os itens da compra e efetiva
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return;
            }
            
            var compra = (Compra)lstCompras.SelectedItem;
            if(compra.Status != eStatusDaCompra.NOVA)
            {
                MessageBox.Show("Essa compra já foi efetivada!");
                return;
            }
            if(compra.ItensDaCompra.Count == 0)
            {
                MessageBox.Show("Nenhum item a ser comprado nessa solicitação de compra.");
                return;
            }
            var itensDaCompra = obtenhaListaDeItensDaCompra(compra);
            var listaAgrupada = itensDaCompra.GroupBy(x => x.Produto.Fornecedor).ToList();
            string listaString = "Prezado, <br> Por favor enviar os seguintes produtos relacionados na lista abaixo:<br><ul>";
            foreach(var item in listaAgrupada)
            {
                var fornecedor = item.Key;
                var itens = item.ToList();
                foreach(var itemDaCompra in itens)
                {
                    listaString += $"<li>{itemDaCompra.Quantidade} - {itemDaCompra.Produto.Nome}  {itemDaCompra.Produto.Marca.Nome} - {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", itemDaCompra.Produto.ValorDeCompra)}<br></li>";
                }
                //Enviar Email
                listaString += "</ul>";
                EnviarEmail(fornecedor.Email, "Solicitação de compra", listaString);

            }

           

            //Atualiza o banco de dados informado que a compra foi realizada
            compra.Status = eStatusDaCompra.EFETIVADA;
            compra.DataDeEfetivacao = DateTime.Now;
            repositorio.Atualize(compra);
            CarregueElementosDoBancoDeDados();

        }

       

        private static List<ItemDaCompra> obtenhaListaDeItensDaCompra(Compra compra)
        {
            var repositorioItemDaCompra = new RepositorioItemDaCompra();
            var itensDaCompra = repositorioItemDaCompra.Liste(compra.Codigo);
            return itensDaCompra;
        }
    }
}
