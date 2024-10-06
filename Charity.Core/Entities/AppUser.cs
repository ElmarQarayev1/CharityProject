using System;
using Microsoft.AspNetCore.Identity;

namespace Charity.Core.Entities
{
	public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

    }
}

