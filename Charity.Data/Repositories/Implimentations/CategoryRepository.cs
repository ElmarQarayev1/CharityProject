using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Impimentations
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context)
        {
        }
    }
}

