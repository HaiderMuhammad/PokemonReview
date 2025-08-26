using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonReview.Dto;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Controllers;


[Route("api/[controller]")]
[ApiController]

public class OwnerController: Controller
{
     private readonly IOwnerRepository _ownerRepository;
     private readonly IMapper _mapper;
     
     public OwnerController(IOwnerRepository ownerRepository, IMapper mapper)
     {
          _ownerRepository = ownerRepository;
          _mapper = mapper;
     }
     
     [HttpGet]
     [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
     public IActionResult GetOwners()
     {
          var owners = _mapper.Map<List<OwnerDto>>(_ownerRepository.GetOwners());

          if (!ModelState.IsValid)
               return BadRequest(ModelState);
          return Ok(owners);
     }
}