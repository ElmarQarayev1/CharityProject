using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Implimentations
{
	public class TestimoneyRepository : Repository<Testimony>, ITestimonyRepository
    {
		public TestimoneyRepository(AppDbContext context):base(context)
		{
		}
	}
}

