using System;
namespace Charity.Service.Dtos.Tag
{
	public class TagGetDto
	{
		public int Id { get; set; }

		public string Name { get; set; }

        public int NewsTagCount { get; set; }
    }
}

