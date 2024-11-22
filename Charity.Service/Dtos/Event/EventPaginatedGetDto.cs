using System;
using Microsoft.AspNetCore.Http;

namespace Charity.Service.Dtos.Event
{
	public class EventPaginatedGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public DateTime Date { get; set; }

        public string StartingTime { get; set; }

        public int CategoryId { get; set; }

        public string Phone { get; set; }

        public string WebSite { get; set; }

        public string Location { get; set; }
    }
}

