using AutoMapper;
using PokemonReview.data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository;

public class OwnerRepository: IOwnerRepository
{
    private readonly DataContext _context;
    private readonly IMapper  _mapper;

    public OwnerRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public ICollection<Owner> GetOwners()
    {
        return _context.Owners.ToList();
    }

    public Owner GetOwner(int ownerId)
    {
        return _context.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
    }

    public ICollection<Owner> GetOwnerOfAPokemon(int pokeId)
    {
        return _context.PokemonOwners.Where(p => p.Pokemon.Id == pokeId)
            .Select(o => o.Owner).ToList();
    }

    public ICollection<Pokemon> GetPokemonByOwner(int ownerId)
    {
        return _context.PokemonOwners.Where(p => p.OwnerId == ownerId)
            .Select(p => p.Pokemon).ToList();
    }

    public bool OwnerExists(int ownerId)
    {
        return _context.Owners.Any(o => o.Id == ownerId);
    }
}