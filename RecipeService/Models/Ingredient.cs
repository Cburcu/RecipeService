using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeService.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public Amount Amount { get; set; }
        public string Name { get; set; }
        public int RecipeId { get; set; }
    }
}