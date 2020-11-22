using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public IActionResult Get(string name)
        {
            try
            {
                var basicPokemon = _pokemonService.GetPokemon(name);
                var translation = _translationService.GetTranslation(basicPokemon.Description);

                return Ok(new PokemonCharacter(name, translation));
            }
            catch (ApiException ex)
            {
                return NotFound(new ApiException(ex.ErrorCode, ex.ErrorMessage));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(HttpStatusCode.BadRequest, ex.Message));
            }

        }
    }
}
