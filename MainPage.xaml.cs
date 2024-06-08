using FIPE.Models;
using FIPE.Repository;
using FIPE.Util;
using System.Reflection;

namespace FIPE
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private static string sTipoVeiculo;
        private static string sCodFabricante;
        private static string sCodModelo;
        private static string sAno;

        public MainPage()
        {
            InitializeComponent();
            CarregarTipos();
        }

        public void CarregarTipos()
        {
            pickerTipos.Title = "Selecione o tipo de veículo";
            pickerTipos.ItemsSource = VeiculosRepository.ListarVeiculos();
            pickerTipos.ItemDisplayBinding = new Binding("Descricao");
        }

        void SelTipo(object sender, EventArgs e) 
        {
            var pickerTipo = (Picker)sender;
            int selectedIndex = pickerTipo.SelectedIndex;

            if (selectedIndex != -1)
            {
                Veiculos veiculos = (Veiculos)pickerTipo.ItemsSource[selectedIndex];
                sTipoVeiculo = veiculos.Tipo;
                CarregarFabricantes(sTipoVeiculo);
            }
        }
        private void CarregarFabricantes(string tipoVeiculo)
        {
            pickerFabricantes.Title = "Selecione o fabricante do veículo";
            pickerFabricantes.ItemsSource = FabricantesRepository.ListarFabricantes(tipoVeiculo);
            pickerFabricantes.ItemDisplayBinding = new Binding("nome");

        }
        void SelFabricante(object sender, EventArgs e)
        {
            var pickerFabricante = (Picker)sender;
            int selectedIndex = pickerFabricante.SelectedIndex;

            if (selectedIndex != -1)
            {
                Fabricantes fabricante = (Fabricantes)pickerFabricante.ItemsSource[selectedIndex];
                sCodFabricante = fabricante.codigo;
                CarregarModelos(sCodFabricante);
            }
        }
        private void CarregarModelos(string codigo)
        {
            pickerModelos.Title = "Selecione o Modelo do veículo";
            pickerModelos.ItemsSource = ModelosRepository.ListarModelos(sTipoVeiculo, codigo);
            pickerModelos.ItemDisplayBinding = new Binding("nome");
        }

        void SelModelo(object sender, EventArgs e)
        {
            var pickerModelos = (Picker)sender;
            int selectedIndex = pickerModelos.SelectedIndex;

            if (selectedIndex != -1)
            {
                Modelos model = (Modelos)pickerModelos.ItemsSource[selectedIndex];
                sCodModelo = model.codigo;
                CarregarAnos(sCodModelo);
            }
        }

        private void CarregarAnos(string codigo)
        {
            pickerAno.Title = "Selecione o Ano do veículo";
            pickerAno.ItemsSource = AnoRepository.ListarAno(sTipoVeiculo, sCodFabricante, codigo);
            pickerAno.ItemDisplayBinding = new Binding("nome");
        }

        void SelAno(object sender, EventArgs e)
        {
            var pickerAnos = (Picker)sender;
            int selectedIndex = pickerAnos.SelectedIndex;

            if (selectedIndex != -1)
            {
                Ano ano = (Ano)pickerAnos.ItemsSource[selectedIndex];
                sAno = ano.codigo;
            }
        }
        private void ValidatePickers()
        {
            if (pickerTipos.SelectedItem == null)
            {
                throw new ValidationException("O Tipo deve ser preenchido.");
            }
            if (pickerFabricantes.SelectedItem == null)
            {
                throw new ValidationException("O Fabricante deve ser preenchido.");
            }
            if (pickerModelos.SelectedItem == null)
            {
                throw new ValidationException("O Modelo deve ser preenchido.");
            }
            if (pickerAno.SelectedItem == null)
            {
                throw new ValidationException("O Ano deve ser preenchido.");
            }
        }

        private async void OnPesquisar(object sender, EventArgs e)
        {
            try
            {
                ValidatePickers();
                PesquisaPreco dados = PesquisaPrecoRepository.RetornaVeiculo(sTipoVeiculo, sCodFabricante, sCodModelo, sAno);
                lblPreco.Text = "R$ " + dados.Valor;
                lblModelo.Text = dados.Modelo;
            }
            catch (ValidationException ex)
            {
                await DisplayAlert("Erro de Validação", ex.Message, "OK");
            }

        }
    }

}
