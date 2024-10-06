using System;
namespace Charity.Core.Entities
{
	public class AuditEntity:BaseEntity
	{
		public DateTime CreateAt { get; set; } =  DateTime.Now;

		public DateTime ModifiedAt { get; set; }
	}
}

