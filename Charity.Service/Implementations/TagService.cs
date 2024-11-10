using System;
using AutoMapper;
using Charity.Core.Entities;
using Charity.Data.Repositories.Impimentations;
using Charity.Data.Repositories.Interfaces;
using Charity.Service.Dtos.Category;
using Charity.Service.Dtos.Tag;
using Charity.Service.Exceptions;
using Charity.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Charity.Service.Implementations
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        public TagService(ITagRepository tagRepository,IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;

        }
        public int Create(TagCreateDto tagCreateDto)
        {
            if (_tagRepository.Exists(x => x.Name == tagCreateDto.Name))
            {
                throw new RestException(StatusCodes.Status400BadRequest, "Name", "Name already taken");
            }

            var entity = new Core.Entities.Tag
            {
                Name = tagCreateDto.Name
            };

            _tagRepository.Add(entity);
            _tagRepository.Save();
            return entity.Id;
        }

        //deletee ucun 
        public void Delete(int Id)
        {
            Tag tag = _tagRepository.Get(x => x.Id == Id);

            if (tag == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Tag Not Found");
            }
            _tagRepository.Delete(tag);
            _tagRepository.Save();
        }

        public List<TagGetDto> GetAll(string? search = null)
        {
            var tags = _tagRepository.GetAll(x => search == null || x.Name.Contains(search)).ToList();

            return _mapper.Map<List<TagGetDto>>(tags);
        }

        public PaginatedList<TagPaginatedGetDto> GetAllByPage(string? search = null, int page = 1, int size = 10)
        {
            var query = _tagRepository.GetAll(x => x.Name.Contains(search) || search == null, "NewsTags");


            var paginated = PaginatedList<Tag>.Create(query, page, size);

            var tags = _mapper.Map<List<TagPaginatedGetDto>>(paginated.Items);

            return new PaginatedList<TagPaginatedGetDto>(tags, paginated.TotalPages, page, size);
        }

        public TagGetDto GetById(int Id)
        {
            Tag tag = _tagRepository.Get(x => x.Id == Id);
            if (tag == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Name", "Tag Not Found");
            }
            return _mapper.Map<TagGetDto>(tag);
        }

        public void Update(int Id, TagUpdateDto categoryUpdateDto)
        {
            Tag tag = _tagRepository.Get(x => x.Id == Id);
            if (tag == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Name", "Tag Not Found");
            }

            if (tag.Name != categoryUpdateDto.Name && _tagRepository.Exists(x => x.Name == categoryUpdateDto.Name))
            {
                throw new RestException(StatusCodes.Status400BadRequest, "Name", "Tag already taken");
            }
            tag.Name = categoryUpdateDto.Name;
            _tagRepository.Save();
        }
    }
}

