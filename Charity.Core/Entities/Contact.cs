using System;
using System.ComponentModel.DataAnnotations;

namespace Charity.Core.Entities
{
	public class Contact
	{
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? AppUserId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
       
        public string? Email { get; set; }
      
        public string Text { get; set; }
       
        public string Subject { get; set; }

        public AppUser? AppUser { get; set; }
    }
}

