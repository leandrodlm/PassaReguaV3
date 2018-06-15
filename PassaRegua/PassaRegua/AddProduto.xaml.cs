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
        List<Pessoa> list = new List<Pessoa>();

        public AddProduto(MainPage m)
        {
            
            InitializeComponent();

            mp = m;
            foreach (Pessoa p in mp.pessoas)
            {
                list.Add(p);
            }

            listaPessoasPicker.ItemsSource = list;

        }



        async void BtnAdicionar_clicked(object sender, EventArgs e)
        {
            try
            {
                Double v = Double.Parse(valor.Text);
                mp.AddProduto(listaPessoasPicker.Items[listaPessoasPicker.SelectedIndex], produto.Text, v);
                await Navigation.PopModalAsync();
            }
            catch(Exception ex)
            {
                await DisplayAlert("Alerta", ex.Message, "OK");
            }
        }

        async void BtnVoltar_clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}