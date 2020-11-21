using System;
using Pokemon.Models;

namespace Pokemon.Services.Interfaces
{
    public interface IPokemonRepository
    {
        public PokemonCharacteristic GetCharacteristic(string name);
        public RawPokemon GetPokemon(string name);
    }
}
