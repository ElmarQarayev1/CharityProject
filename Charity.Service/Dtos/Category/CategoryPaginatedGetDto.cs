using System;
namespace Charity.Service.Dtos.Category
{
	public class CategoryPaginatedGetDto
	{
        public int Id { get; set; }
        public string Name { get; set; }

        public int EventCount { get; set; }
    }
}

