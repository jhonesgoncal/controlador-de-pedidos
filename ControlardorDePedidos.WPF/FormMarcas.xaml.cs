using System.Windows;
using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;

namespace ControladorDePedidos.WPF
{
    public partial class FormMarcas : Window
    {
        RepositorioMarca repositorio; 
        public FormMarcas()
        {
            repositorio = new RepositorioMarca();
            InitializeComponent();
        }

        private void FormMarcas_OnLoaded(object sender, RoutedEventArgs e)
        {
          CarregueElementosDoBancoDeDados();

        }

        private void CarregueElementosDoBancoDeDados()
        {
            lstMarcas.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroMarca = new FormCadastroDeMarca();
            formCadastroMarca.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            
            if (lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }else
            {
                var itemSelecionado = (Marca)lstMarcas.SelectedItem;
                var formCadastroMarca = new FormCadastroDeMarca(itemSelecionado);
                formCadastroMarca.ShowDialog();
                CarregueElementosDoBancoDeDados();
            }
          
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
       
            if (lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Marca) lstMarcas.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElementosDoBancoDeDados();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }
    }
}
