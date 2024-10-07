using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Implimentations
{
	public class EventRepository : Repository<Event>, IEventRepository
    {
		public EventRepository(AppDbContext context):base(context)
		{
		}
	}
}

