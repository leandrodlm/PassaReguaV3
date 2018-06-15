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
        public Fatura(String nome, List<ProdutoConsumido> fPessoa)
        {
            InitializeComponent();

            nomePessoa.Text = nome;
            fatura.ItemsSource = fPessoa;
        }

        async void BtnVoltar_clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}