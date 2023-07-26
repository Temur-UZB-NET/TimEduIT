using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Service.Dtos.Courses;
using TimEduIT.Service.Interfaces.Courses;
using TimEduIT.Service.Validators.Courses;

namespace TimEduIT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService _coursesService;
        private readonly int maxPageSize = 30;

        public CoursesController(ICoursesService coursesService)
        {
            _coursesService = coursesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
             => Ok(await _coursesService.GetAllAsync(new PaginationParams(page, maxPageSize)));


        [HttpGet("{courseId}")]
        public async Task<IActionResult> GetByIdAsync(long courseId)
             => Ok(await _coursesService.GetByIdAsync(courseId));


        [HttpGet("count")]
        public async Task<IActionResult> CountAsync()
            => Ok(await _coursesService.CountAsync());


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CourseCreateDto dto)
        {
            var createValidator = new CourseCreateValidator();
            var result = createValidator.Validate(dto);
            if (result.IsValid) return Ok(await _coursesService.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("{courseId}")]
        public async Task<IActionResult> UpdateAsync(long courseId, [FromForm] CoursesUpdateDto dto)
        {
            var updateValidator = new CoursesUpdateValidator();
            var result = updateValidator.Validate(dto);
            if (result.IsValid) return Ok(await _coursesService.UpdateAsync(courseId, dto));
            else return BadRequest(result.Errors);
        }


        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteAsync(long courseId)
      => Ok(await _coursesService.DeleteAsync(courseId));
    }
}
