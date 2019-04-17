using System.Collections.Generic;

namespace RecipeService.Models
{
    public class RootObject
    {
        public int Results { get; set; }
        public int Total { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
