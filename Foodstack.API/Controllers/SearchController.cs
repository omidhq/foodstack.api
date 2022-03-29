#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Foodstack.API.Models;
using Foodstack.API.Services;

namespace Foodstack.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SearchController : ControllerBase
  {
    private readonly FoodstackContext _context;
    private readonly ISpoonacularClient _client;

    public SearchController(FoodstackContext context, ISpoonacularClient client)
    {
      _context = context;
      _client = client;
    }

    [HttpGet("recipe")]
    public async Task<ActionResult<IEnumerable<RecipeResponse>>> GetRecipes()
    {
      string[] ingredients = {"apples", "sugar", "flour"};
      return await _client.GetRecipes(ingredients);
    }

    // GET: api/Search
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredient()
    {
      return await _context.Ingredients.ToListAsync();
    }

    // GET: api/Search/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ingredient>> GetIngredient(int id)
    {
      var ingredient = await _context.Ingredients.FindAsync(id);

      if (ingredient == null)
      {
        return NotFound();
      }

      return ingredient;
    }

    // PUT: api/Search/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutIngredient(int id, Ingredient ingredient)
    {
      if (id != ingredient.Id)
      {
        return BadRequest();
      }

      _context.Entry(ingredient).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!IngredientExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Search
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
    {
      _context.Ingredients.Add(ingredient);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
    }

    // DELETE: api/Search/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(int id)
    {
      var ingredient = await _context.Ingredients.FindAsync(id);
      if (ingredient == null)
      {
        return NotFound();
      }

      _context.Ingredients.Remove(ingredient);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool IngredientExists(int id)
    {
      return _context.Ingredients.Any(e => e.Id == id);
    }
  }
}
