using System;
using Charity.Core.Entities.Enums;

namespace Charity.Core.Entities
{
	public class NewsReview:BaseEntity
	{
        public string AppUserId { get; set; }

        public int? NewsId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ReviewStatus Status { get; set; } = ReviewStatus.Pending;

        public string Text { get; set; }

        public AppUser? AppUser { get; set; }

        public News? News { get; set; }

    }
}

