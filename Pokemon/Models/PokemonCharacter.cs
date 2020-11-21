using System;
namespace Pokemon.Models
{
    public class PokemonCharacter
    {
        private string name;
        private string description;

        public PokemonCharacter(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
