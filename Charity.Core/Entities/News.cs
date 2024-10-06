using System;
namespace Charity.Core.Entities
{
	public class News : AuditEntity
	{
		public string Name { get; set; }

		public DateTime Date { get; set; }

		public string Desc { get; set; }

        public string ImageName { get; set; }

        public List<NewsTag> NewsTags { get; set; }

		

	}
}

