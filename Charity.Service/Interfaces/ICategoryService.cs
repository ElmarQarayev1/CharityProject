using System;
using Charity.Service.Dtos.Category;

namespace Charity.Service.Interfaces
{
	public interface ICategoryService
	{
		int Create(CategoryCreateDto categoryCreateDto);
		List<CategoryGetDto> GetAll(string? search=null);
		PaginatedList<CategoryPaginatedGetDto> GetAllByPage(string? search = null, int page = 1, int size = 10);
		CategoryGetDto GetById(int Id);
		void Delete(int Id);
		void Update(int Id, CategoryUpdateDto categoryUpdateDto);
	}
}

