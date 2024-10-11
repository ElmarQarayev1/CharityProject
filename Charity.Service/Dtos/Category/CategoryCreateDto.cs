using System;
using FluentValidation;

namespace Charity.Service.Dtos.Category
{
	public class CategoryCreateDto
	{
		public string Name { get; set; }
	}

	public  class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
	{
		public CategoryCreateDtoValidator()
		{
			RuleFor(x => x.Name).NotNull().MaximumLength(30).MinimumLength(2);
		}
	}
}

