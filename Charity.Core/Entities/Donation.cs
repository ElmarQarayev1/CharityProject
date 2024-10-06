using System;
namespace Charity.Core.Entities
{
	public class Donation:AuditEntity
	{
		public string Image { get; set; }

		public string Desc { get; set; }

		public double Goal { get; set; }

		public double Raised { get; set; }

		public List<DonationImage> DonationImages { get; set; }
	}
}

