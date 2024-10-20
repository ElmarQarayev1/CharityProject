using System;
using FluentValidation;

namespace Charity.Service.Dtos.Tag
{
	public class TagUpdateDto
	{
		public string Name { get; set; }
	}
    public class TagUpdateDtoValidator : AbstractValidator<TagUpdateDto>
    {
        public TagUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(30).MinimumLength(2);
        }
    }
}

