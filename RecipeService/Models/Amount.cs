namespace RecipeService.Models
{
    public class Amount
    {
        public int AmountId { get; set; }
        public string Quantity { get; set; }
        public string Unit { get; set; }
        public int IngredientId { get; set; }
    }
}