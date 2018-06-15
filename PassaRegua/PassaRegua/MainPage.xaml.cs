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
        }

        public void AddNovaPessoa(string entradaNome)
        {
            pessoas.Add(new Pessoa { nomePessoa = entradaNome, valorTotal = 0 });
        }

        public void AddProduto(Pessoa p, double valor)
        {

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

        public void BtnFecharConta_clicked(object sender, EventArgs e)
        {

        }
    }
}
