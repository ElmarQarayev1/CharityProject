using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Implimentations
{
	public class NewsRepository : Repository<News>, INewsRepository
    {
		public NewsRepository(AppDbContext context):base(context)
		{
		}
	}
}

