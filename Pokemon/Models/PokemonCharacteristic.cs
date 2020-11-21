using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pokemon.Models
{
    public partial class PokemonCharacteristic
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("gene_modulo")]
        public long GeneModulo { get; set; }

        [JsonProperty("possible_values")]
        public long[] PossibleValues { get; set; }

        [JsonProperty("highest_stat")]
        public HighestStat HighestStat { get; set; }

        [JsonProperty("descriptions")]
        public Description[] Descriptions { get; set; }
    }

    public partial class Description
    {
        [JsonProperty("description")]
        public string DescriptionText { get; set; }

        [JsonProperty("language")]
        public HighestStat Language { get; set; }
    }

    public partial class HighestStat
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

}
