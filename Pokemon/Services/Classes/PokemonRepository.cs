using System;
using Microsoft.Extensions.Configuration;
using Pokemon.Models;
using Pokemon.Services.Interfaces;
using RestSharp;

namespace Pokemon.Services.Classes
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly IConfiguration _configuration;

        public PokemonRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public PokemonCharacteristic GetCharacteristic(string id)
        {
            var client = new RestClient(_configuration["ApiSettings:pokeApiUrl"] + "characteristic/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<PokemonCharacteristic>(request);

            return response.Data;
        }

        public RawPokemon GetPokemon(string name)
        {
            var client = new RestClient(_configuration["ApiSettings:pokeApiUrl"] + "pokemon/"+name);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            var response = client.Execute<RawPokemon>(request);

            return response.Data;
        }
    }
}
