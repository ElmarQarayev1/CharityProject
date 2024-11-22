using System;
using AutoMapper;
using Charity.Core.Entities;
using Charity.Service.Dtos.Category;
using Charity.Service.Dtos.Event;
using Charity.Service.Dtos.Tag;
using Microsoft.AspNetCore.Http;

namespace Charity.Service.Profiles
{
    public class MapProfile:Profile
    {
        private readonly IHttpContextAccessor _context;

        public MapProfile(IHttpContextAccessor httpContextAccessor)
        {
            _context = httpContextAccessor;

            var uriBuilder = new UriBuilder(_context.HttpContext.Request.Scheme, _context.HttpContext.Request.Host.Host, _context.HttpContext.Request.Host.Port ?? -1);

            if (uriBuilder.Uri.IsDefaultPort)
            {
                uriBuilder.Port = -1;
            }
            string baseUrl = uriBuilder.Uri.AbsoluteUri;


            //Categories
            CreateMap<Category, CategoryGetDto>();

            CreateMap<Category, CategoryPaginatedGetDto>()
                .ForMember(dest => dest.EventCount, s => s.MapFrom(s => s.Events.Count));

            //tags

            CreateMap<Tag, TagGetDto>();

            CreateMap<Tag, TagPaginatedGetDto>()
                .ForMember(dest => dest.NewsTagCount, s => s.MapFrom(s => s.NewsTags.Count));


            //Events

            CreateMap<Event, EventGetDto>().
                  ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => baseUrl + "/uploads/events/" + src.ImageName));
            CreateMap<Event, EventPaginatedGetDto>()
                  .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => baseUrl + "/uploads/events/" + src.ImageName))
                  .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));

        }
    }
}

