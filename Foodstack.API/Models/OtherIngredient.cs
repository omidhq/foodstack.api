using System.Text.Json.Serialization;

namespace Foodstack.API.Models;

public class OtherIngredient
{
  [JsonPropertyName("name")]              
  public string? Name { get; set; }

  [JsonPropertyName("original")]  
  public string? FullName { get; set; }
}