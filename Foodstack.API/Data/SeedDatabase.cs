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

      var filePath = Path.Combine("Data", "ingredients.txt");

      if (context.Ingredients.Any() || !File.Exists(filePath))
      {
        return;
      }

      var allLines = File.ReadAllLines(filePath);

      foreach (var ingredientStr in allLines)
      {
        context.Ingredients.Add(new Ingredient { Name = ingredientStr });
      }
      context.SaveChanges();
    }
  }
}