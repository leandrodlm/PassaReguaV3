using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassaRegua
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduto : ContentPage
    {
        MainPage mp;

        public AddProduto(MainPage m)
        {
            mp = m;

            // List<Pessoa> list = new List<Pessoa>(mp.pessoas);

            //listaPessoasPicker.ItemsSource = list;

            // Picker pick = AddProduto.

            // listaPessoasPicker.ItemsSource = new ObservableCollection<Pessoa>(list as List<Pessoa>);



            listaPessoasPicker.ItemsSource = new List<Pessoa>(mp.pessoas);

            // var opcoesSelecaoPessoa = mp.pessoas;
            // listapessoass.ItemsSource = mp.pessoas;
            // ObservableCollection<Pessoa> novaLista = mp.pessoas;
            //listaPessoasPicker.Items.Add("Olá!");

            InitializeComponent();
        }



        async void BtnAdicionar_clicked(object sender, EventArgs e)
        {

            // mp.AddNovaPessoa(nomePessoa.Text);

            await Navigation.PopModalAsync();
        }

        async void BtnVoltar_clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}