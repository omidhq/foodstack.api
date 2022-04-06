using System.Text.Json.Serialization;

namespace Foodstack.API.Models;

public class RecipeResponse
{
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("title")]
  public string? Name { get; set; }

  [JsonPropertyName("image")]
  public string? ImageUrl { get; set; }

  [JsonPropertyName("missedIngredients")]  
  public List<OtherIngredient>? MissingIngredients { get; set; }

  [JsonPropertyName("unusedIngredients")]  
  public List<OtherIngredient>? UnusedIngredients { get; set; }

  [JsonPropertyName("usedIngredients")]  
  public List<OtherIngredient>? UsedIngredients { get; set; }
}