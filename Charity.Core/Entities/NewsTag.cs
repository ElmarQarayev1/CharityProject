using System;
namespace Charity.Core.Entities
{
	public class NewsTag
	{
		public int TagId { get; set; }

		public int NewsId { get; set; }

		public Tag Tag { get; set; }

		public News News { get; set; }
	}
}

