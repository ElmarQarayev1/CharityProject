using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Implimentations
{
	public class VolunteerRepository : Repository<Volunteer>, IVolunteerRepository
    {
		public VolunteerRepository(AppDbContext context):base(context)
		{
		}
	}
}

