using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeSheakspeare.Common;
using PokeSheakspeare.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokeSheakspeare.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly ILogger<PokemonController> _logger;
        private readonly IPokeProvider _pokeProvider;
        private readonly ISheakspeareTranslator _sheakspeareTranslator;

        public PokemonController(ILogger<PokemonController> logger, ISheakspeareTranslator sheakspeareTranslator, IPokeProvider pokeProvider)
        {
            _pokeProvider = pokeProvider;
            _sheakspeareTranslator = sheakspeareTranslator;
            _logger = logger;
        }

        // GET /pokemon/name
        [HttpGet("{pokemonName}")]
        public async Task<ActionResult> GetAsync(string pokemonName)
        {
            try
            {
                _logger.LogInformation("Pokemon Info started on - " + pokemonName);
                var description = await _pokeProvider.GetDescriptionAsync(pokemonName);
                var translation = await _sheakspeareTranslator.GetTranslationAsync(description);
                var pokeDescription = new PokemonDescription() { description = translation, name = pokemonName };
                return Ok(pokeDescription);
            }
            catch (RequestException re)
            {
                if (re.statusCode == HttpStatusCode.NotFound)
                {
                    return NotFound(re.Message);
                }
                else
                {
                    return BadRequest(re.Message);
                }
            }
        }
    }
}
