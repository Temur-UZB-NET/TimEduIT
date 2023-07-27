using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.DataAccess.Interfaces.Videos;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Domain.Entities.Videos;
using TimEduIT.Domain.Exceptions.File;
using TimEduIT.Domain.Exceptions.Video;
using TimEduIT.Service.Common.Helpers;
using TimEduIT.Service.Dtos.Videos;
using TimEduIT.Service.Interfaces.Common;
using TimEduIT.Service.Interfaces.Videos;
using TimEduIT.Service.Service.Common;

namespace TimEduIT.Service.Service.Videos;

public class VideoService : IVideoService
{
    private IVideoRepository _repository;
    private IVideoProtsesService _videoService;
    private IPoginator _paginator;
    private IFileService _fileService;

    public VideoService(IVideoRepository videoRepository,
        IVideoProtsesService videoProtsesService,
        IPoginator poginator,
        IFileService fileService)
    {
        this._repository = videoRepository;
        this._videoService = videoProtsesService;
        this._paginator = poginator;
        this._fileService = fileService;
    }
    public async Task<long> CountAsync() => await _repository.CountAsync();


    public async Task<bool> CreateAsync(VideoCreateDto dto)
    {
        string videoPath = await _videoService.VideoUploadAsync(dto.Video)!;
        string imagePath = await _fileService.UploadImageAsync(dto.Image);
        var video = new VideoModel()
        {
            CoursesId = dto.CourseId,
            Description = dto.Description,
            VideoPath = videoPath!,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };
        var result = await _repository.CreateAsync(video);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long videoId)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new VideoNotFoundException();

        var result = await _videoService.VideoDeleteAsync(video.VideoPath);
        if (result == false) throw new VideoNotFoundException();


        var dbResult = await _repository.DeleteAsync(videoId);
        return dbResult > 0;
    }

    public async Task<IList<VideoModel>> GetAllAsync(PaginationParams @params)
    {
        var videos = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return videos;
    }

    public async Task<VideoModel> GetByIdAsync(long videoId)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new VideoNotFoundException();
        return video;
    }

    public async Task<bool> UpdateAsync(long videoId, VideoUpdateDto dto)
    {
        var video = await _repository.GetByIdAsync(videoId);
        if (video is null) throw new VideoNotFoundException();

        video.Description = dto.Description;

        if (dto.Video is not null)
        {
            var deleteResult = await _videoService.VideoDeleteAsync(video.VideoPath);
            if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _videoService.VideoUploadAsync(dto.Video);

            video.VideoPath = newImagePath;
        }


        video.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(videoId, video);
        return dbResult > 0;
    }

    Task<IList<Video>> IVideoService.GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    Task<Video> IVideoService.GetByIdAsync(long videoId)
    {
        throw new NotImplementedException();
    }
}
