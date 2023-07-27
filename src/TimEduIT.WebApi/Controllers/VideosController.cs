using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Service.Dtos.Videos;
using TimEduIT.Service.Interfaces.Videos;
using TimEduIT.Service.Validators.Dtos.Videos;

namespace TimEduIT.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;

        private readonly int maxPageSize = 30;

        public VideosController(IVideoService videoService)
        {
            this._videoService = videoService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
       => Ok(await _videoService.GetAllAsync(new PaginationParams(page, maxPageSize)));


        [HttpGet("{videoId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetByIdAsync([FromQuery] long videoId)
        => Ok(await _videoService.GetByIdAsync(videoId));

        [HttpGet("count")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CountAsynv() => Ok(await _videoService.CountAsync());



        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 314572801)]
        [RequestSizeLimit(314572801)]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateAsync([FromForm] VideoCreateDto dto)
        {
            var createValidator = new VideoCreateValidator();
            var result = createValidator.Validate(dto);
            if (result.IsValid) return Ok(await _videoService.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        [HttpPut("{videoId}")]
        [RequestFormLimits(MultipartBodyLengthLimit = 314572800)]
        [RequestSizeLimit(314572800)]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateAsync(long videoId, [FromForm] VideoUpdateDto dto)
        {
            var updateValidator = new VideoUpdateValidator();
            var result = updateValidator.Validate(dto);
            if (result.IsValid) return Ok(await _videoService.UpdateAsync(videoId, dto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete("{videoId}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(long videoId)
        => Ok(await _videoService.DeleteAsync(videoId));
    }
}
