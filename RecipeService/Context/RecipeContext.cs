using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeService.Exceptions;
using RecipeService.Models;

namespace RecipeService.Context
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<Recipe>().HasMany<Category>(r => r.Categories);
                modelBuilder.Entity<Recipe>().HasMany<Ingredient>(r => r.Ingredients);
                modelBuilder.Entity<Recipe>().HasMany<Direction>(r => r.Directions);
            }
            catch (Exception e)
            {
                throw ExceptionsCodes.InternalError;
            }
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Amount> Amount { get; set; }

    }
}
