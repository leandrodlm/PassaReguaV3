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

        ObservableCollection<Pessoa> pessoas = new ObservableCollection<Pessoa>();

        public MainPage()
        {

            InitializeComponent();
            listapessoas.ItemsSource = pessoas;
        }

        public void AddNovaPessoa(string entradaNome)
        {
            pessoas.Add(new Pessoa { nomePessoa = entradaNome });
        }

        async void BtnAdicionarPessoaPage_clicked(object sender, EventArgs e)
        {
            var addPage = new AddPage(this);
            addPage.BindingContext = pessoas;
            await Navigation.PushModalAsync(addPage);
        }

        async void BtnAdicionarProdutoPage_clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddProduto(), true);
        }

        public void BtnFecharConta_clicked(object sender, EventArgs e)
        {


        }
    }
}
