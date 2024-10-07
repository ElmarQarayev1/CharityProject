using System;
using Charity.Core.Entities;
using Charity.Data.Repositories.Interfaces;

namespace Charity.Data.Repositories.Impimentations
{
    public class AuthRepository:Repository<AppUser>,IAuthRepository
    {
        public AuthRepository(AppDbContext context):base(context)
        {
        }
    }
}

