using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Implimentations
{
	public class TagRepository : Repository<Tag>, ITagRepository
    {
		public TagRepository(AppDbContext context):base(context)
		{
		}
	}
}

