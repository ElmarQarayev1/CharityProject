using System;
using Charity.Service.Dtos.Category;
using Charity.Service.Dtos.Tag;

namespace Charity.Service.Interfaces
{
	public interface ITagService
	{
		int Create(TagCreateDto tagCreateDto);

        List<TagGetDto> GetAll(string? search = null);
        PaginatedList<TagPaginatedGetDto> GetAllByPage(string? search = null, int page = 1, int size = 10);
        TagGetDto GetById(int Id);
        void Delete(int Id);
        void Update(int Id, TagUpdateDto categoryUpdateDto);
    }
}

