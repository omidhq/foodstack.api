using Microsoft.EntityFrameworkCore;
using Foodstack.API.Models;
using System.IO;

public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new FoodstackContext(
        serviceProvider.GetRequiredService<
            DbContextOptions<FoodstackContext>>()))
    {

      if (context.Ingredients.Any())
      {
        return;
      }

      var allLines = File.ReadAllLines("ingredients.txt");

      foreach (var ingredientStr in allLines)
      {
        context.Ingredients.Add(new Ingredient { Name = ingredientStr });
      }
      context.SaveChanges();
    }
  }
}