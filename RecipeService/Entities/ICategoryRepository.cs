using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeService.Models;

namespace RecipeService.Entities
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
