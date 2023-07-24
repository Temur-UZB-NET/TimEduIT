using TimEduIT.DataAccess.Interfaces.Categories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Service.Interfaces.Categories;
using TimEduIT.Service.Dtos.Categories;
using TimEduIT.Service.Validators.Dtos;

namespace TimEduIT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly int maxPageSize = 50;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _categoryService.GetAllAsync(new PaginationParams(page, maxPageSize)));


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CategoryCreatDto dto)
        {
            var createValidator = new CategoryCreateValidator();
            var result = createValidator.Validate(dto);
            if (result.IsValid) return Ok(await _categoryService.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

    }
}
