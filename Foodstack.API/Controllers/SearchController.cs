#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foodstack.API.Models;
using Foodstack.API.Services;

namespace Foodstack.API.Controllers
{
  [Route("api")]
  [ApiController]
  public class SearchController : ControllerBase
  {
    private readonly FoodstackContext _context;
    private readonly ISpoonacularClient _client;

    public SearchController(FoodstackContext context, ISpoonacularClient client)
    {
      _context = context;
      _client = client;
    }

    [HttpGet("recipes")]
    public async Task<ActionResult<IEnumerable<RecipeResponse>>> GetRecipes(string ingredients)
    {
      var splitIngredients = ingredients.Split(',');
      return await _client.GetRecipes(splitIngredients);
    }

    // GET: api/Search
    [HttpGet("ingredients")]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
    {
      return await _context.Ingredients.ToListAsync();
    }

    [HttpGet("recipesinfo")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesInformation(string ids)
    {
      return await _client.GetRecipesInformation(ids);
    }

    [HttpGet("instructions")]
    public async Task<ActionResult<IEnumerable<Steps>>> GetRecipeInstructions(string recipeId)
    {
      return await _client.GetRecipeInstructions(recipeId);
    }
  }
}