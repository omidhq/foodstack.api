using Foodstack.API.Models;

namespace Foodstack.API.Services;

public interface ISpoonacularClient
{
  public Task<List<Recipe>?> GetRecipesInformation(string ids);
  public Task<List<RecipeResponse>?> GetRecipes(IEnumerable<string> ingredients);
  public Task<List<Steps>?> GetRecipeInstructions(string recipeId);
}