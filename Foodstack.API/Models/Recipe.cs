using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Foodstack.API.Models;

public class Recipe
{
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("title")]
  [Required, MaxLength(127)]
  public string? Name { get; set; }

  [JsonPropertyName("summary")]
  [Required, MaxLength(500)]
  public string? Description { get; set; }

  [JsonPropertyName("image")]
  public string? ImageUrl { get; set; }

  // [JsonPropertyName("")]
  [Range(0, 5)]
  public int Rating { get; set; }

  public string? Difficulty { get; set; }

  [JsonPropertyName("readyInMinutes")]
  public int CookingTimeInMinutes { get; set; }
}