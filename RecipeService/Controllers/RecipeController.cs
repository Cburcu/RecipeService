using System;
using Microsoft.AspNetCore.Mvc;
using RecipeService.Entities;
using RecipeService.Exceptions;
using RecipeService.Models;

namespace RecipeService.Controllers
{
    [Route("services/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        public readonly IRecipeRepository _RecipeRepository;
        public readonly ICategoryRepository _CategoryRepository;

        public RecipeController(IRecipeRepository recipeRepository, ICategoryRepository categoryRepository)
        {
            _RecipeRepository = recipeRepository;
            _CategoryRepository = categoryRepository;
        }

        // Post: services/recipe/all
        // Post: services/recipe/all?page=1&pagesize=10
        [HttpPost("all")]
        public ActionResult<RootObject> GetAll(int page = 1, int pagesize = 5)
        {
            var rootObject = new RootObject();
            try
            {
                var recipes = _RecipeRepository.GetAll(page, pagesize);
                rootObject.Recipes = recipes;
                rootObject.Total = recipes.Count;
                rootObject.Results = page;

                return Ok(rootObject);
            }
            catch (ExceptionsCodes ex)
            {
                return StatusCode(ex.statusCode, ex.message);
            }
            catch
            {
                return
                    StatusCode(ExceptionsCodes.InternalError.statusCode, ExceptionsCodes.InternalError.message);
            }
        }

        // Put: services/recipe/add
        [HttpPut("add")]
        public ActionResult AddRecipe([FromBody]Recipe recipe)
        {
            try
            {
                _RecipeRepository.Add(recipe);
                return StatusCode(ExceptionsCodes.Succeccful.statusCode, ExceptionsCodes.Succeccful.message);
            }
            catch (ExceptionsCodes ex)
            {
                return StatusCode(ex.statusCode, ex.message);
            }
            catch
            {
                return StatusCode(ExceptionsCodes.InternalError.statusCode, ExceptionsCodes.InternalError.message);
            }
        }

        /// Get: services/recipe/filter/categories
        [HttpGet("filter/categories")]
        public ActionResult<RootObject> GetAllCategories()
        {
            try
            {
                var catgoriesList = _CategoryRepository.GetAll();
                return Ok(catgoriesList);
            }
            catch (ExceptionsCodes ex)
            {
                return StatusCode(ex.statusCode, ex.message);
            }
            catch (Exception e)
            {
                return StatusCode(ExceptionsCodes.InternalError.statusCode, ExceptionsCodes.InternalError.message);
            }
        }
    }
}
