#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Foodstack.API.Models;

public class FoodstackContext : DbContext
{
  public FoodstackContext(DbContextOptions<FoodstackContext> options)
      : base(options)
  {
  }

  public DbSet<Foodstack.API.Models.Ingredient> Ingredients { get; set; }
}
