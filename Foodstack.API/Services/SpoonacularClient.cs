using Foodstack.API.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Foodstack.API.Services;

public class SpoonacularClient : ISpoonacularClient
{
  private readonly string _key;

  public SpoonacularClient(string key)
  {
    _key = key;
  }
  public async Task<List<RecipeResponse>?> GetRecipes(IEnumerable<string> ingredients)
  {
    var formattedIngredients = ingredients.Aggregate("", (current, next) => current += next + ",+");
    var requestedIngredients = formattedIngredients.Remove(formattedIngredients.Length - 2);

    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

    var url = @$"https://api.spoonacular.com/recipes/findByIngredients?ingredients={requestedIngredients}&number=100&apiKey={_key}";
    var response = await client.GetStreamAsync(url);

    return JsonSerializer.Deserialize<List<RecipeResponse>>(response);
  }

  public Task<List<Recipe>> GetRecipesInformation()
  {
    throw new NotImplementedException();
  }
}