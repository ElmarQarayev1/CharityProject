using System;
namespace Charity.Core.Entities
{
	public class Slider:BaseEntity
	{

		public string Name { get; set; }

		public string Image { get; set; }

		public int Order { get; set; }
	}
}

