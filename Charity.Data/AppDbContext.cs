using System;
using Charity.Core.Entities;
using Charity.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Charity.Data
{
	public class AppDbContext:IdentityDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{

		}

		public DbSet<AppUser> AppUsers { get; set; }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Donation> Donations { get; set; }

		public DbSet<DonationImage> DonationImages { get; set; }

		public DbSet<Event> Events { get; set; }

		public DbSet<Contact> Contacts { get; set; }

		public DbSet<News> News { get; set; }

		public DbSet<NewsReview> NewsReviews { get; set; }

		public DbSet<NewsTag> NewsTags { get; set; }

		public DbSet<Tag> Tags { get; set; }

		public DbSet<Slider> Sliders { get; set; }

		public DbSet<Testimony> Testimonies { get; set; }

		public DbSet<Volunteer> Volunteers { get; set; }

		public DbSet<DonateMoney> DonateMoney { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.ApplyConfiguration(new NewsTagConfig());

            base.OnModelCreating(builder);
        }
    }
}

