using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pokemon.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Description
    {
        public string description { get; set; }
        public Language language { get; set; }
    }

    public class HighestStat
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonCharacteristic
    {
        public List<Description> descriptions { get; set; }
        public int gene_modulo { get; set; }
        public HighestStat highest_stat { get; set; }
        public int id { get; set; }
        public List<int> possible_values { get; set; }
    }


}
