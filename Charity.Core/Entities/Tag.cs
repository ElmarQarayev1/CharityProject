using System;
namespace Charity.Core.Entities
{
	public class Tag:BaseEntity
	{
		public string Name { get; set; }

		public List<NewsTag> NewsTags { get; set; }
	}
}

