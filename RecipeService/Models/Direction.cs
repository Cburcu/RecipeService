namespace RecipeService.Models
{
    public class Direction
    {
        public int DirectionId { get; set; }
        public string Step { get; set; }
        public int RecipeId { get; set; }
    }
}