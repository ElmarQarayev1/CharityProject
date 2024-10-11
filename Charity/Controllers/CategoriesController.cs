using System;
using Charity.Service;
using Charity.Service.Dtos.Category;
using Charity.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
	[ApiController]
	public class CategoriesController:Controller
	{
		private readonly ICategoryService _categoryService;
		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpPost("api/admin/categories")]

		public ActionResult Create(CategoryCreateDto categoryCreateDto)
		{
			return StatusCode(201, new { Id = _categoryService.Create(categoryCreateDto) });
		}
        [HttpGet("api/admin/categories")]
        public ActionResult<PaginatedList<CategoryPaginatedGetDto>> GetAll(string? search = null, int page = 1, int size = 10)
        {
            return StatusCode(200, _categoryService.GetAllByPage(search, page, size));
        }

        [HttpGet("api/admin/categories/all")]
        public ActionResult<List<CategoryGetDto>> GetAll()
        {
            return StatusCode(200, _categoryService.GetAll());
        }
        [HttpGet("api/admin/categories/{id}")]
        public ActionResult<CategoryGetDto> GetById(int id)
        {
            return StatusCode(200, _categoryService.GetById(id));
        }

        [HttpPut("api/admin/Categories/{id}")]
        public IActionResult Update(int id, CategoryUpdateDto updateDto)
        {
            _categoryService.Update(id, updateDto);
            return NoContent();
        }

        [HttpDelete("api/admin/categories/{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return NoContent();
        }



    }
}

