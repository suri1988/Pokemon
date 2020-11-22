using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokemon.Models;
using Pokemon.Services.Interfaces;

namespace Pokemon.Controllers
{
    [Route("api/Pokemon")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IPokemonService _pokemonService;
        private ITranslationService _translationService;
         
        public PokemonController(IPokemonService pokemonService, ITranslationService translationService)
        {
            _pokemonService = pokemonService;
            _translationService = translationService;
        }

        [HttpGet("{name}")]
        public PokemonCharacter Get(string name)
        {
            var basicPokemon = _pokemonService.GetPokemon(name);
            var translation = _translationService.GetTranslation(basicPokemon.Description);

            return new PokemonCharacter(name, translation);
        }
    }
}
