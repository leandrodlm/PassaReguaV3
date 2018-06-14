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

            /*
            PessoasView = this.FindByName<ListView>("listapessoas");
            pessoas = new List<String>() { "João" };
            PessoasView.ItemsSource = pessoas;
            */

            listapessoas.ItemsSource = pessoas;

            // AddNovaPessoa();

        }

        public class Pessoa
        {
            public string nomePessoa { get; set; }
        }

        public void AddNovaPessoa()
        {
            pessoas.Add(new Pessoa { nomePessoa = "Rob Finnerty" });
        }


        async void btnAdicionarPessoa_clicked(object sender, EventArgs e)
        {
            var addPage = new AddPage();

            await Navigation.PushModalAsync(addPage);
        }

        async void btnAdicionarProduto_clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddProduto(), true);
        }

        public void btnFecharConta_clicked(object sender, EventArgs e)
        {


        }
    }
}
