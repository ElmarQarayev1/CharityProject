using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Implimentations
{
	public class DonateMoneyRepository : Repository<DonateMoney>, IDonateMoneyRepository
    {
		public DonateMoneyRepository(AppDbContext context):base(context)
		{
		}
	}
}

