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

        public ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();
        public List<ProdutoConsumido> fatura = new List<ProdutoConsumido>();

        private int idCount = 0;

        public MainPage()
        {
            InitializeComponent();

            listaPessoas.ItemsSource = pessoas;
        }

        public void AddNovaPessoa(string entradaNome)
        {
            pessoas.Add(new Pessoa { ID = idCount, nomePessoa = entradaNome, valorTotal = 0 });
            idCount++;
            listaPessoas.ItemsSource = pessoas;
        }

        public void AddProduto(String nome, String nmProduto, Double valor)
        {
            ObservableCollection<Pessoa> newPessoas = new ObservableCollection<Pessoa>();

            foreach (Pessoa p in pessoas)
            {
                if (p.nomePessoa.CompareTo(nome) == 0)
                {
                    fatura.Add(new ProdutoConsumido { IDpessoa = p.ID, nomeProduto = nmProduto, valorProduto = valor });
                    p.addValue(valor);
                }
                newPessoas.Add(p);
            }

            listaPessoas.ItemsSource = newPessoas;
        }

        public void LimparMesa()
        {
            pessoas = new ObservableCollection<Pessoa>();
            listaPessoas.ItemsSource = pessoas;
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
                    pFinalizada.Add(p);
                }

                if (answer)
                {
                    pFinalizada = new List<Pessoa>();
                    foreach (Pessoa p in pessoas)
                    {
                        pFinalizada.Add(new Pessoa { nomePessoa = p.nomePessoa, valorTotal = (p.valorTotal + ((valorDaConta * 0.1) / pessoas.Count)) });
                    }

                    await Navigation.PushModalAsync(new ContaFinalizada(this, pFinalizada, (valorDaConta + (valorDaConta * 0.1))));
                }
                else
                {
                    await Navigation.PushModalAsync(new ContaFinalizada(this, pFinalizada, valorDaConta));
                }
            }
            else
            {
                await DisplayAlert("Alerta", "Não é possível fechar uma mesa vazia!", "OK");
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Pessoa pessoa = (Pessoa)e.SelectedItem;
            List<ProdutoConsumido> pCons = new List<ProdutoConsumido>();

            foreach (ProdutoConsumido pc in fatura)
            {
                if (pc.IDpessoa == pessoa.ID)
                {
                    pCons.Add(pc);
                }
            }

            await Navigation.PushModalAsync(new Fatura(pessoa.nomePessoa, pCons));
        }
    }
}
