using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecipeService.Context;
using RecipeService.Entities;
using RecipeService.Exceptions;
using RecipeService.Models;

namespace RecipeService.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        public readonly RecipeContext _RecipeContext;

        public RecipeRepository(RecipeContext recipeContext)
        {
            _RecipeContext = recipeContext;
        }

        public void Add(Recipe recipe)
        {
            var recipes = _RecipeContext.Recipes.ToList();
            if (recipes.Count !=0)
            {
                var recipesList = recipes.Where(r => r.Title.Equals(recipe.Title)).ToList();

                if (recipesList.Count == 0)
                {
                    _RecipeContext.Recipes.Add(recipe);
                    _RecipeContext.SaveChanges();
                }
                else
                {
                    throw ExceptionsCodes.DuplicatedContent;
                }
            }
            else
            {
                throw ExceptionsCodes.InternalError;
            }
        }

        public List<Recipe> GetAll(int page, int pagesize)
        {
            var recipes = _RecipeContext.Recipes
                .Include(recipe => recipe.Categories)
                .Include(recipe => recipe.Directions)
                .Include(recipe => recipe.Ingredients).ThenInclude(ingredient => ingredient.Amount)
                .Skip((page - 1) * pagesize).Take(pagesize)
                .ToList();

            if (recipes.Count != 0)
            {
                return recipes;
            }
            else
            {
                throw ExceptionsCodes.NoContent;
            }
        }
    }
}
