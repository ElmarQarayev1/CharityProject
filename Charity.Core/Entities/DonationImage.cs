using System;
namespace Charity.Core.Entities
{
	public class DonationImage:BaseEntity
	{
		public string ImageName { get; set; }

		public int NewsId { get; set; }

		public News News { get; set; }

	}
}

