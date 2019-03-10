using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ynovXamarin.ViewModel;
using ynovXamarin.Model;
using Plugin.LocalNotifications;

namespace ynovXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{

        public List<Pokemon> allPokemons;
        public static List<Pokemon> filteredPokemon = new List<Pokemon>();
        public static int start;
        public static int end;

        public MainPage ()
		{
            start = 1;
            end = 151;
            InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            if (allPokemons == null)
            {
                StartLoading();
                allPokemons = await PokemonViewModel.GetMultiplePokemonAsync(start, end);
                StopLoading();
                PokemonListView.ItemsSource = allPokemons;
            }

            base.OnAppearing();
        }

        private void GetKanto(object sender, EventArgs e)
        {
            start = 1;
            end = 151;
            GetPokemons();
        }

        private void GetJhoto(object sender, EventArgs e)
        {
            start = 152;
            end = 251;
            GetPokemons();
        }

        private void GetHoenn(object sender, EventArgs e)
        {
            start = 252;
            end = 385;
            GetPokemons();
        }

        private void GetSinnoh(object sender, EventArgs e)
        {
            start = 386;
            end = 493;
            GetPokemons();
        }

        private void GetKalos(object sender, EventArgs e)
        {
            start = 494;
            end = 565;
            GetPokemons();
        }

        private void GetAlola(object sender, EventArgs e)
        {
            start = 566;
            end = 651;
            GetPokemons();
        }

        private async void GetPokemons()
        {
            allPokemons.Clear();
            PokemonListView.ItemsSource = new List<Pokemon> ();
            StartLoading();
            allPokemons = await PokemonViewModel.GetMultiplePokemonAsync(start, end);
            StopLoading();
            PokemonListView.ItemsSource = allPokemons;
        }

        private void StartLoading()
        {
            loadingGif.WidthRequest = 256;
            loadingGif.HeightRequest = 256;
            loadingGif.Scale = 1;
        }

        private void StopLoading()
        {
            loadingGif.WidthRequest = 0;
            loadingGif.HeightRequest = 0;
            loadingGif.Scale = 0;
        }

        private void HandleSearch(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            string searchValue = search.Text;

            if ( !string.IsNullOrWhiteSpace(searchValue) )
            {
                filteredPokemon = allPokemons.FindAll(poke => poke.Forms[0].Name.ToLower().Contains(searchValue.ToLower()));
                PokemonListView.ItemsSource = filteredPokemon;
            } else if (searchValue == "")
            {
                PokemonListView.ItemsSource = allPokemons;
            }
        }

        private void GoDetails(object sender, EventArgs e)
        {
            ViewCell sending = (ViewCell)sender;
            Pokemon objectCliked = (Pokemon)sending.BindingContext;

            CrossLocalNotifications.Current.Show("POKéMON", "Vous avez séléctionné " + objectCliked.Name);

            Navigation.PushAsync(new PokemonDetails(objectCliked));
        }
    }
}