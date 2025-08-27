using AutoMapper;
using PokemonReview.Dto;
using PokemonReview.Models;

namespace PokemonReview.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<PokemonDto, Pokemon>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Country, CountryDto>();
        CreateMap<Owner, OwnerDto>();
        CreateMap<OwnerDto, Owner>();
        CreateMap<Review, ReviewDto>();
        CreateMap<Reviewer, ReviewerDto>();
    }
}