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
    public partial class AddPage : ContentPage
    {
        MainPage mp;

        public AddPage(MainPage m)
        {
            mp = m;
            InitializeComponent();
        }

        async void BtnAdicionar_clicked(object sender, EventArgs e)
        {

            mp.AddNovaPessoa(nomePessoa.Text);
            await Navigation.PopModalAsync();
        }

        async void BtnVoltar_clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}