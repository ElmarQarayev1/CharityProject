using System;
using FluentValidation;

namespace Charity.Service.Dtos.Category
{
	public class CategoryUpdateDto
	{
		public string Name { get; set; }
	}
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().MaximumLength(30).MinimumLength(2);
        }
    }
}

