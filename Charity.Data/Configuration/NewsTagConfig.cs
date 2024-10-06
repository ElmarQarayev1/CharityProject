using System;
using Charity.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Charity.Data.Configuration
{
	public class NewsTagConfig : IEntityTypeConfiguration<NewsTag>
    {
        public void Configure(EntityTypeBuilder<NewsTag> builder)
        {
            builder.HasKey(x => new { x.NewsId, x.TagId });

            builder.HasOne(rc => rc.News)
                 .WithMany(r => r.NewsTags)
                 .HasForeignKey(rc => rc.NewsId);

            builder.HasOne(rc => rc.Tag)
                   .WithMany(c => c.NewsTags)
                   .HasForeignKey(rc => rc.TagId);
        
    }

    }
}

