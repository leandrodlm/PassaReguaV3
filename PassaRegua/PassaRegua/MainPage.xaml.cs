using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PassaRegua
{
    public partial class MainPage : ContentPage
    {
        //ListView PessoasView;
        //List<String> pessoas;
        //List<String> produtos;

        public ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();

        public MainPage()
        {
            InitializeComponent();

            listapessoas.ItemsSource = pessoas;
            listapessoas.IsPullToRefreshEnabled = true;
        }

        public void AddNovaPessoa(string entradaNome)
        {
            pessoas.Add(new Pessoa { nomePessoa = entradaNome, valorTotal = 0 });
        }

        public void AddProduto(Pessoa p, double valor)
        {

        }

        public void LimparMesa()
        {
            pessoas.Clear();
        }

        async void BtnAdicionarPessoaPage_clicked(object sender, EventArgs e)
        {
            //var addPage = new AddPage(this);
            //addPage.BindingContext = pessoas;
            await Navigation.PushModalAsync(new AddPage(this));
        }

        async void BtnAdicionarProdutoPage_clicked(object sender, EventArgs e)
        {
            //var addProduto = new AddProduto(this);
            //addProduto.BindingContext = pessoas;
            await Navigation.PushModalAsync(new AddProduto(this));
        }

        async void BtnFecharConta_clicked(object sender, EventArgs e)
        {
            if (pessoas.Count != 0)
            {
                Boolean answer = await DisplayAlert("Passar a régua", "Vocês gostariam de pagar os 10%?", "Yes", "No");
                Double valorDaConta = 0;
                List<Pessoa> pFinalizada = new List<Pessoa>();

                foreach (Pessoa p in pessoas)
                {
                    valorDaConta += p.valorTotal;
                }

                foreach (Pessoa p in pessoas)
                {

                    pFinalizada.Add(new Pessoa { nomePessoa = p.nomePessoa, valorTotal = (p.valorTotal + ((valorDaConta * 0.1)/pessoas.Count)) });
                }

                await Navigation.PushModalAsync(new ContaFinalizada(this, pFinalizada, (valorDaConta+(valorDaConta*0.1))));
            }
            else
            {
                DisplayAlert("Alerta", "Não é possível fechar uma mesa vazia!", "OK");
            }
        }
    }
}
