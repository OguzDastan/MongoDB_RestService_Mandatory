using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDB_RestService.Model
{
    public class RecipestoreDatabaseSettings : IRecipestoreDatabaseSettings
    {
        public string RecipeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IRecipestoreDatabaseSettings
    {
        string RecipeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
