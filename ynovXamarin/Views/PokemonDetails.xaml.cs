using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ynovXamarin.Model;

namespace ynovXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PokemonDetails : ContentPage
	{

        Pokemon pokemon;

        public PokemonDetails ( Pokemon pokemon )
		{
            this.pokemon = pokemon;

            Title = "POKéDEX - " + pokemon.Forms[0].Name;

			InitializeComponent ();
		}

        protected override void OnAppearing()
        {

            mooveView.HeightRequest = pokemon.Moves.Count() * 6;

            BindingContext = pokemon;

            base.OnAppearing();
        }

    }
}