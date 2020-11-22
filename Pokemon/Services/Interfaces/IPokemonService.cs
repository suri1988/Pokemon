using System;
using Pokemon.Models;

namespace Pokemon.Services.Interfaces
{
    public interface IPokemonService
    {
        public PokemonCharacter GetPokemon(string name);
    }
}
