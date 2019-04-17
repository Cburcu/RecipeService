using System.Collections.Generic;
using RecipeService.Entities;

namespace RecipeService.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Direction> Directions { get; set; }
    }

}
