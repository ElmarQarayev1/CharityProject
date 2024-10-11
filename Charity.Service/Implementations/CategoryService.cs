using System;
using AutoMapper;
using Charity.Core.Entities;
using Charity.Data.Repositories.Interfaces;
using Charity.Service.Dtos.Category;
using Charity.Service.Exceptions;
using Charity.Service.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Charity.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;


        public CategoryService( ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public int Create(CategoryCreateDto categoryCreateDto)
        {

            if (_categoryRepository.Exists(x => x.Name == categoryCreateDto.Name))
            {
                throw new  RestException(StatusCodes.Status400BadRequest,"Name", "Cate already taken");
            }

            var entity = new Category
            {
                Name = categoryCreateDto.Name
            };

            _categoryRepository.Add(entity);
            _categoryRepository.Save();

            return entity.Id;            
        }

        public void Delete(int Id)
        {
            Category category = _categoryRepository.Get(x => x.Id == Id);

            if (category == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Category Not Found");
            }
            _categoryRepository.Delete(category);
            _categoryRepository.Save();
        }

        public List<CategoryGetDto> GetAll(string? search = null)
        {
            var categories = _categoryRepository.GetAll(x=> search==null || x.Name.Contains(search)).ToList();

            return _mapper.Map<List<CategoryGetDto>>(categories);
        }

        public PaginatedList<CategoryPaginatedGetDto> GetAllByPage(string? search = null, int page = 1, int size = 10)
        {
            var query = _categoryRepository.GetAll(x => x.Name.Contains(search) || search == null, "Events");


            var paginated = PaginatedList<Category>.Create(query, page, size);

            var categoryDtos = _mapper.Map<List<CategoryPaginatedGetDto>>(paginated.Items);

            return new PaginatedList<CategoryPaginatedGetDto>(categoryDtos, paginated.TotalPages, page, size);
        }

        public CategoryGetDto GetById(int Id)
        {
            Category category = _categoryRepository.Get(x => x.Id == Id);
            if (category == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Name", "Category Not Found");
            }
            return _mapper.Map<CategoryGetDto>(category);
        }

        public void Update(int Id, CategoryUpdateDto categoryUpdateDto)
        {
            Category category = _categoryRepository.Get(x => x.Id == Id);
            if (category == null)
            {
                throw new RestException(StatusCodes.Status404NotFound, "Name", "Category Not Found");
            }

            if (category.Name != categoryUpdateDto.Name && _categoryRepository.Exists(x => x.Name == categoryUpdateDto.Name))
            {
                throw new RestException(StatusCodes.Status400BadRequest, "Name", "Category already taken");
            }
            category.Name = categoryUpdateDto.Name;
            _categoryRepository.Save();
        }
    }
}

