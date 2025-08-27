using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Dto;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PokemonController : Controller
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;
    public PokemonController(IPokemonRepository _pokemonRepository,
        IReviewRepository reviewRepository, IMapper  mapper)
    {
        this._pokemonRepository = _pokemonRepository;
        this._mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemons()
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(pokemons);
    }

    [HttpGet("{pokeId}")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemon(int pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
            return NotFound();

        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemon);

    }
    
    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreatePokemon([FromQuery] int ownerId, [FromQuery] int catId, [FromBody] PokemonDto pokemonCreate)
    {
        if (pokemonCreate == null)
            return BadRequest(ModelState);

        var pokemons = _pokemonRepository.GetPokemonTrimToUpper(pokemonCreate);

        if (pokemons != null)
        {
            ModelState.AddModelError("", "Owner already exists");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemonMap = _mapper.Map<Pokemon>(pokemonCreate);

      
        if (!_pokemonRepository.CreatePokemon(ownerId, catId, pokemonMap))
        {
            ModelState.AddModelError("", "Something went wrong while savin");
            return StatusCode(500, ModelState);
        }

        return Ok("Successfully created");
    }

    [HttpGet("{pokeId}/rating")]
    [ProducesResponseType(200, Type = typeof(Pokemon))]
    [ProducesResponseType(400)]
    public IActionResult GetPokemonRating(int pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
            return NotFound();
        
        var rating = _pokemonRepository.GetPokemonRating(pokeId);
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(rating);
            
    }
}