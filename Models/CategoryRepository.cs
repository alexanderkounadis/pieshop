using BethanysPieShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext ctx;

        public CategoryRepository(AppDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IEnumerable<Category> AllCategories => ctx.Categories;
    }
}
