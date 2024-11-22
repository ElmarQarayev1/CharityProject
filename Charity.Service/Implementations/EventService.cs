using System;
using System.Numerics;
using AutoMapper;
using Charity.Core.Entities;
using Charity.Data.Repositories.Interfaces;
using Charity.Service.Dtos.Event;
using Charity.Service.Exceptions;
using Charity.Service.Helpers;
using Charity.Service.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Charity.Service.Implementations
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        private readonly IWebHostEnvironment _env;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public EventService(IEventRepository eventRepository,IWebHostEnvironment webHostEnvironment,ICategoryRepository categoryRepository,IMapper mapper)
        {
            _env = webHostEnvironment;
            _eventRepository = eventRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public int Create(EventCreateDto eventCreateDto)
        {
            var validator = new EventCreateDtoValidator();

            var validationResult = validator.Validate(eventCreateDto);


            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var category = _categoryRepository.Get(x => x.Id == eventCreateDto.CategoryId);

            if (category == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Cateogory Not Found");
            }

            var phone = _eventRepository.Get(x => x.Phone == eventCreateDto.Phone);

            if (phone != null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Phone already exists");
            }

            Event @event = new Event()
            {
                Phone = eventCreateDto.Phone,
                Location = eventCreateDto.Location,
                Name = eventCreateDto.Name,
                Date = eventCreateDto.Date,
                StartingTime = eventCreateDto.StartingTime,
                CategoryId = eventCreateDto.CategoryId,
                WebSite = eventCreateDto.WebSite,
                ImageName = FileManager.Save(eventCreateDto.File, _env.WebRootPath, "uploads/events")

            };
            _eventRepository.Add(@event);
            _eventRepository.Save();
            return @event.Id;

    }
        public void Delete(int Id)
        {
            Event @event = _eventRepository.Get(x => x.Id == Id);

            if (@event == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Event not found");
            }

            _eventRepository.Delete(@event);

            _eventRepository.Save();

            FileManager.Delete(_env.WebRootPath, "uploads/doctors", @event.ImageName);
        }

        public List<EventGetDto> GetAll(string? search = null)
        {
            var events = _eventRepository.GetAll(x => search == null || x.Name.Contains(search)).ToList();
            return _mapper.Map<List<EventGetDto>>(events);
        }

        public PaginatedList<EventPaginatedGetDto> GetAllByPage(string? search = null, int page = 1, int size = 10)
        {
            var query = _eventRepository.GetAll(x => x.Name.Contains(search) || search == null, "Category");

            var paginated = PaginatedList<Event>.Create(query, page, size);

            var eventDtos = _mapper.Map<List<EventPaginatedGetDto>>(paginated.Items);

            return new PaginatedList<EventPaginatedGetDto>(eventDtos, paginated.TotalPages, page, size);
        }

        public EventGetDto GetById(int Id)
        {
            Event @event = _eventRepository.Get(x => x.Id == Id);

            if (@event == null)
                throw new RestException(StatusCodes.Status404NotFound, "Event not found");

            return _mapper.Map<EventGetDto>(@event);
        }

        public void Update(int Id, EventUpdateDto eventUpdateDto)
        {
            var events = _eventRepository.Get(x => x.Id == Id);

            if (events == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Id", "Event not found by given Id");
            }

            var validator = new EventUpdateDtoValidator();

            var validationResult = validator.Validate(eventUpdateDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var category = _categoryRepository.Get(x => x.Id == eventUpdateDto.CategoryId);

            if (category == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Category not found");
            }

            if (events.Phone != eventUpdateDto.Phone)
            {
                var doctorEmail = _eventRepository.Get(x => x.Phone == eventUpdateDto.Phone);
                if (doctorEmail != null)
                {
                    throw new RestException(StatusCodes.Status400BadRequest, "There cannot be a doctor with the same phone");
                }
            }

            
            string deletedFile = events.ImageName;

            if (!string.IsNullOrEmpty(eventUpdateDto.Name))
            {
                events.Name = eventUpdateDto.Name;
            }

            if (!string.IsNullOrEmpty(eventUpdateDto.WebSite))
            {
                events.WebSite = eventUpdateDto.WebSite;
            }

            if (!string.IsNullOrEmpty(eventUpdateDto.Location))
            {
                events.Location = eventUpdateDto.Location;
            }
            if (!string.IsNullOrEmpty(eventUpdateDto.StartingTime))
            {
                events.StartingTime = eventUpdateDto.StartingTime;
            }

           
            events.Date = eventUpdateDto.Date;                

            if (eventUpdateDto.File != null)
            {
                events.ImageName = FileManager.Save(eventUpdateDto.File, _env.WebRootPath, "uploads/events");
            }

            events.CategoryId = events.CategoryId;
           

            _eventRepository.Save();


            if (deletedFile != null && deletedFile != events.ImageName)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/events", deletedFile);
            }
        }
    }
}

