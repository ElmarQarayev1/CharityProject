using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Impimentations
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(AppDbContext context):base(context)
        {
        }
    }
}

