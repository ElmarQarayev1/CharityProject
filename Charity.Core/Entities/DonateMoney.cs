using System;
namespace Charity.Core.Entities
{
	public class DonateMoney:BaseEntity
	{

		public string AppUserId { get; set; }

		public double money { get; set; }

		public int DonationId { get; set; }

		public Donation Donation { get; set; }
	}
}

