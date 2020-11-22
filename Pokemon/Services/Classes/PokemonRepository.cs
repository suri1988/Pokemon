using System;
using Pokemon.Models;
using Pokemon.Services.Interfaces;
using RestSharp;

namespace Pokemon.Services.Classes
{
    public class PokemonRepository : IPokemonRepository
    {
        public PokemonCharacteristic GetCharacteristic(string id)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/characteristic/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<PokemonCharacteristic>(request);

            return response.Data;
        }

        public RawPokemon GetPokemon(string name)
        {
            var client = new RestClient("https://pokeapi.co/api/v2/pokemon/"+name);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<RawPokemon>(request);

            return response.Data;
        }
    }
}
