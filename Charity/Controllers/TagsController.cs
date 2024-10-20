using System;
using Charity.Service;
using Charity.Service.Dtos.Category;
using Charity.Service.Dtos.Tag;
using Charity.Service.Implementations;
using Charity.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Charity.Controllers
{
	[ApiController]
	public class TagsController:Controller
	{
		private readonly ITagService _tagService;

		public TagsController(ITagService tagService)
		{
			_tagService = tagService;

		}
        [HttpPost("api/admin/tags")]

        public ActionResult Create(TagCreateDto tagCreateDto)
        {
            return StatusCode(201, new { Id = _tagService.Create(tagCreateDto) });
        }
        [HttpGet("api/admin/tags")]
        public ActionResult<PaginatedList<TagPaginatedGetDto>> GetAll(string? search = null, int page = 1, int size = 10)
        {
            return StatusCode(200, _tagService.GetAllByPage(search, page, size));
        }

        [HttpGet("api/admin/tags/all")]
        public ActionResult<List<TagGetDto>> GetAll()
        {
            return StatusCode(200, _tagService.GetAll());
        }
        [HttpGet("api/admin/tags/{id}")]
        public ActionResult<TagGetDto> GetById(int id)
        {
            return StatusCode(200, _tagService.GetById(id));
        }

        [HttpPut("api/admin/tags/{id}")]
        public IActionResult Update(int id, TagUpdateDto updateDto)
        {
            _tagService.Update(id, updateDto);
            return NoContent();
        }

        [HttpDelete("api/admin/tags/{id}")]
        public IActionResult Delete(int id)
        {
            _tagService.Delete(id);
            return NoContent();
        }


    }
}

