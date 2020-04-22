using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB_RestService.Model;
using MongoDB_RestService.Services;

namespace MongoDB_RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService rs;

        public RecipeController(RecipeService recipeService)
        {
            rs = recipeService;
        }

        // GET: api/Recipe
        [HttpGet]
        public ActionResult<List<Recipe>> Get()
        {
            return rs.Get();
        }

        // GET: api/Recipe/5
        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Recipe> Get(string id)
        {
            var recipe = rs.Get(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        [HttpPost]
        public ActionResult<Recipe> Create(Recipe recipe)
        {
            rs.Create(recipe);

            return CreatedAtRoute("GetBook", new { id = recipe.Id.ToString() }, recipe);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Recipe recipeIn)
        {
            var recipe = rs.Get(id);

            if (recipe == null)
            {
                return NotFound();
            }

            rs.Update(id, recipeIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var recipe = rs.Get(id);

            if (recipe == null)
            {
                return NotFound();
            }

            rs.Remove(recipe.Id);

            return NoContent();
        }
    }
}
