using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using ynovXamarin.Model;

namespace ynovXamarin.ViewModel
{
    class PokemonViewModel
    {
        private static readonly string url = "https://pokeapi.co/api/v2/pokemon/";

        public static Pokemon GetPokemon(int pokemonId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + pokemonId.ToString());
            Pokemon newPokemon;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string res = reader.ReadToEnd();
                newPokemon = JsonConvert.DeserializeObject<Pokemon>(res);
            }

            return newPokemon;
        }

        public static List<Pokemon> GetMultiplePokemon(int start = 1, int end = 151)
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            for (int i = start; i <= end; i++)
            {
                pokemons.Add(GetPokemon(i));
            }

            return pokemons;
        }
    }
}
