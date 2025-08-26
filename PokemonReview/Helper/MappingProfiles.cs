using AutoMapper;
using PokemonReview.Dto;
using PokemonReview.Models;

namespace PokemonReview.Helper;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pokemon, PokemonDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Owner, OwnerDto>();
        CreateMap<Country, CountryDto>();
        CreateMap<Review, ReviewDto>();
        CreateMap<Reviewer, ReviewerDto>();
    }
}