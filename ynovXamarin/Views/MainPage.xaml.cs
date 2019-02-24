﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ynovXamarin.ViewModel;
using ynovXamarin.Model;

namespace ynovXamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{

        public List<Pokemon> allPokemons;
        public List<Pokemon> filteredPokemon = new List<Pokemon>();

        public MainPage ()
		{
            InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            allPokemons = PokemonViewModel.GetMultiplePokemon();

            PokemonListView.ItemsSource = allPokemons;

            base.OnAppearing();
        }

        private void AddPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddPage());
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

            Navigation.PushAsync(new PokemonDetails(objectCliked));
        }
    }
}