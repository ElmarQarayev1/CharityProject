using System;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Charity.Service.Dtos.Event
{
    public class EventCreateDto
    {
        public string Name { get; set; }

        public IFormFile File { get; set; }

        public DateTime Date { get; set; }

        public string StartingTime { get; set; }

        public int CategoryId { get; set; }

        public string Phone { get; set; }

        public string WebSite { get; set; }

        public string Location { get; set; }
    }
    public class EventCreateDtoValidator : AbstractValidator<EventCreateDto>
    {

        public EventCreateDtoValidator()
        {
            RuleFor(x => x.File)
              .Must(file => file == null || file.Length <= 2 * 1024 * 1024)
              .WithMessage("File must be less than or equal to 2MB.")
              .Must(file => file == null || new[] { "image/png", "image/jpeg" }.Contains(file.ContentType))
              .WithMessage("File type must be png, jpeg, or jpg.");

            RuleFor(x => x.Name).NotNull().MinimumLength(2).MaximumLength(50);

            RuleFor(x => x.WebSite).NotNull().MinimumLength(2).MaximumLength(500);

            RuleFor(x => x.Location).NotNull().MinimumLength(2).MaximumLength(200);

            RuleFor(x => x.Date)
           .NotNull()
           .GreaterThanOrEqualTo(DateTime.Today)
           .WithMessage("Date cannot be in the past.");

        }
    }

}
