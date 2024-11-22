using System;
using Charity.Service.Dtos.Category;
using Charity.Service.Dtos.Event;

namespace Charity.Service.Interfaces
{
	public interface IEventService
	{
        int Create(EventCreateDto eventCreateDto);
        List<EventGetDto> GetAll(string? search = null);
        PaginatedList<EventPaginatedGetDto> GetAllByPage(string? search = null, int page = 1, int size = 10);
        EventGetDto GetById(int Id);
        void Delete(int Id);
        void Update(int Id, EventUpdateDto categoryUpdateDto);
    }
}

