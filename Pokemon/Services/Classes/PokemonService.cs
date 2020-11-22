using System;
using System.Linq;
using Pokemon.Models;
using Pokemon.Services.Interfaces;

namespace Pokemon.Services.Classes
{
    public class PokemonService : IPokemonService
    {
        private IPokemonRepository _pokemonRepository;
        public PokemonService(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public PokemonCharacter GetPokemon(string name)
        {
            var rawPokemon = _pokemonRepository.GetPokemon(name);
            if (rawPokemon == null)
            {
                throw new ApiException(System.Net.HttpStatusCode.NotFound, "No such Pokemon exists!");
            }
            var pokemonCharacteristic = _pokemonRepository.GetCharacteristic(rawPokemon.Id);
            if (pokemonCharacteristic == null)
            {
                throw new ApiException(System.Net.HttpStatusCode.NotFound, "No Pokemon description exists");
            }

            var englishDescription = pokemonCharacteristic.descriptions.FirstOrDefault(d => d.language.name == "en");
            if (englishDescription == null)
            {
                throw new ApiException(System.Net.HttpStatusCode.NotFound, "No English description exists for this Pokemon");
            }

            return new PokemonCharacter(rawPokemon.Name, englishDescription.description);
        }

    }
}
