using Foodstack.API.Models;

namespace Foodstack.API.Services;

public interface ISpoonacularClient
{
  public Task<List<Recipe>> GetRecipesInformation();
  public Task<List<RecipeResponse>?> GetRecipes(IEnumerable<string> ingredients);
}