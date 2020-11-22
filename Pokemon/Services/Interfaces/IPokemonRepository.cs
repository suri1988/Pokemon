using System;
using Pokemon.Models;

namespace Pokemon.Services.Interfaces
{
    public interface IPokemonRepository
    {
        public PokemonCharacteristic GetCharacteristic(int id);
        public RawPokemon GetPokemon(string name);
    }
}
