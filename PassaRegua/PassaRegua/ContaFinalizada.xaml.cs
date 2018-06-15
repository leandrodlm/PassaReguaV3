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
	public partial class ContaFinalizada : ContentPage
	{
        public List<Pessoa> pessoas = new List<Pessoa>();
        public Double total;
        MainPage mp;

        public ContaFinalizada (MainPage m, List<Pessoa> p, Double t)
		{
			InitializeComponent ();

            pessoas = p;
            total = t;
            mp = m;

            listapessoas.ItemsSource = pessoas;
        }

        async void btnFecharMesa_Clicked(object sender, EventArgs e)
        {

            mp.LimparMesa();
            await Navigation.PopModalAsync();
        }
    }
}