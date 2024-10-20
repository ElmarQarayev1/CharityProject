using System;
namespace Charity.Service.Dtos.Tag
{
	public class TagPaginatedGetDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int NewsTagCount { get; set; }
	}
}

