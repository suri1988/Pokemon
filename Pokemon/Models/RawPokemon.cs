using System;
using Newtonsoft.Json;

namespace Pokemon.Models
{
    public class RawPokemon
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
