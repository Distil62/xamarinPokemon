using System.Collections.Generic;
using System.Net;
using System.IO;

using Newtonsoft.Json;

using ynovXamarin.Model;
using System.Threading.Tasks;
using System;

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

        public static List<Pokemon> GetMultiplePokemon(int start, int end)
        {
            List<Pokemon> pokemons = new List<Pokemon>();

            for (int i = start; i <= end; i++)
            {
               pokemons.Add(GetPokemon(i));
            }

            return pokemons;
        }

        public static async Task<string> GetPokemonAsStringAsync(int pokemonId)
        {
            var uri = new Uri(url + pokemonId.ToString());
            var webClient = new WebClient();
            var result  = await webClient.DownloadStringTaskAsync(uri);

            return result;
        }

        public static async Task<List<Pokemon>> GetMultiplePokemonAsync(int start, int end)
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            string pokemonStrTask;
            Pokemon currentPkm;

            for (int i = start; i <= end; i++)
            {
                pokemonStrTask = await GetPokemonAsStringAsync(i);
                currentPkm = JsonConvert.DeserializeObject<Pokemon>(pokemonStrTask);
                pokemons.Add(currentPkm);
            }

            return pokemons;
        }

    }
}
