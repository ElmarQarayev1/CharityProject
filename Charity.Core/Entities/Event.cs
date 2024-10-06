using System;
namespace Charity.Core.Entities
{
	public class Event:AuditEntity
	{
	
		public string Name { get; set; }

		public string ImageName { get; set; }

		public DateTime Date { get; set; }

		public string StartingTime { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }

		public string Phone { get; set; }

		public string WebSite { get; set; }

		public string Location { get; set; }


    }
}

