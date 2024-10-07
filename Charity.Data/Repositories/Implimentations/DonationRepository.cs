using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Implimentations
{
	public class DonationRepository : Repository<Donation>, IDonationRepository
    {
		public DonationRepository(AppDbContext context):base(context)
		{
		}
	}
}

