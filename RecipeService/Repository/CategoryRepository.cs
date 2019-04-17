using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeService.Context;
using RecipeService.Entities;
using RecipeService.Exceptions;
using RecipeService.Models;

namespace RecipeService.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly RecipeContext _RecipeContext;
        public CategoryRepository(RecipeContext recipeContext)
        {
            _RecipeContext = recipeContext;
        }

        public List<Category> GetAll()
        {
            var categories = _RecipeContext.Category.ToList();
            if (categories.Count != 0)
            {
                return categories;
            }
            else
            {
                throw ExceptionsCodes.NoContent;
            }
        }
    }
}
