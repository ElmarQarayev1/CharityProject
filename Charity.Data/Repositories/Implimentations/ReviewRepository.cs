using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Implimentations
{
	public class ReviewRepository : Repository<NewsReview>, IReviewRepository
    {
		public ReviewRepository(AppDbContext context):base(context)
		{
		}
	}
}

