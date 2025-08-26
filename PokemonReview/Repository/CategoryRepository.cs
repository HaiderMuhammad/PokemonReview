using AutoMapper;
using PokemonReview.data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository;

public class CategoryRepository : ICategoryRepository
{
    
    private readonly DataContext _context;
    public CategoryRepository(DataContext context)
    {
        this._context = context;
    }
    public ICollection<Category> GetCategories()
    {
        return _context.Categories.OrderBy(c => c.Name).ToList();
    }

    public Category GetCategory(int categoryId)
    {
        return _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
    }

    public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
    {
        return _context.PokemonCategories.Where(e => e.CategoryId == categoryId)
            .Select(c => c.Pokemon).ToList();
    }

    public bool CategoryExists(int id)
    {
        return _context.Categories.Any(c => c.Id == id);
    }
}