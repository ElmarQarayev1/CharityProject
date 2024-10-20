using System;
using Charity.Service.Dtos.Category;
using FluentValidation;

namespace Charity.Service.Dtos.Tag
{
	public class TagCreateDto
	{
		public string Name { get; set; }
	}
    public class TagCreateDtoValidator : AbstractValidator<TagCreateDto>
    {
        public TagCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(30).MinimumLength(2);
        }
    }

}

