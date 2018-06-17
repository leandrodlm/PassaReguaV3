using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PassaRegua
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Fatura : ContentPage
    {
        MainPage mp;
        int idPessoa;

        public Fatura(Pessoa pessoa, List<ProdutoConsumido> fPessoa, MainPage m)
        {
            InitializeComponent();

            mp = m;

            nomePessoa.Text = pessoa.nomePessoa;
            fatura.ItemsSource = fPessoa;
            idPessoa = pessoa.ID;
        }

        async void BtnVoltar_clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void BtnExcluir_clicked(object sender, EventArgs e)
        {
            try
            {
                //mp.AddProduto(listaPessoasPicker.Items[listaPessoasPicker.SelectedIndex], produto.Text, v);
                mp.RemoverPessoa(idPessoa);
                await Navigation.PopModalAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "OK");
            }
        }
    }
}