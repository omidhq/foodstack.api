using System.ComponentModel.DataAnnotations;

namespace Foodstack.API.Models;

public class Ingredient
{
  public int Id { get; set; }

  [Required, MaxLength(55)]
  public string? Name { get; set; }
}