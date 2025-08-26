using PokemonReview.Models;

namespace PokemonReview.Interfaces;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
    
    Review GetReview(int reviewId);
    
    ICollection<Review> GetReviewsOfPokemon();
    
    bool ReviewExists(int reviewId);
}