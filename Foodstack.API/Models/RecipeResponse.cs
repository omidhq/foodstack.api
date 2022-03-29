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

}