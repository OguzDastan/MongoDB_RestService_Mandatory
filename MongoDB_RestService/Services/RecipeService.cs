using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB_RestService.Model;

namespace MongoDB_RestService.Services
{
    public class RecipeService
    {
        private readonly IMongoCollection<Recipe> _recipes;

        public RecipeService(IRecipestoreDatabaseSettings settings)
        {
            // all connections
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _recipes = database.GetCollection<Recipe>(settings.RecipeCollectionName);

        }

        public List<Recipe> Get() =>
            _recipes.Find(recipe => true).ToList();

        public Recipe Get(string id) =>
            _recipes.Find(recipe => recipe.Id == id).FirstOrDefault();

        public Recipe Create(Recipe recipe)
        {
            _recipes.InsertOne((recipe));
            return recipe;
        }

        public void Update(string id, Recipe recipeIn) =>
            _recipes.DeleteOne(recipe => recipe.Id == id);

        public void Remove(Recipe recipeIn) =>
            _recipes.DeleteOne(recipe => recipe.Id == recipeIn.Id);

        public void Remove(string id) =>
            _recipes.DeleteOne(recipe => recipe.Id == id);
    }
}
