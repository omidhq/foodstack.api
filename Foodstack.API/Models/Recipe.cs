using System.ComponentModel.DataAnnotations;

namespace Foodstack.API.Models;

public class Recipe
{
  public int Id { get; set; }

  [Required, MaxLength(127)]
  public string? Name { get; set; }

  [Required, MaxLength(500)]
  public string? Description { get; set; }

  public string? ImageUrl { get; set; }

  [Range(0, 5)]
  public int Rating { get; set; }

  public string? Difficulty { get; set; }

  public int CookingTimeInMinutes { get; set; }
}