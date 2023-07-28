using DocumentFormat.OpenXml.Office2010.Excel;
using Nest;
using System.Collections.Generic;
using System.Data.Common;
using TimEduIT.DataAccess.Interfaces;
using TimEduIT.DataAccess.Interfaces.Courses;
using TimEduIT.DataAccess.Repositories;
using TimEduIT.DataAccess.Utils;
using TimEduIT.DataAccess.ViewModels.Courses;
using TimEduIT.Domain.Entities.Courses;
using TimEduIT.Domain.Exceptions.Courses;
using TimEduIT.Domain.Exceptions.File;
using TimEduIT.Service.Common.Helpers;
using TimEduIT.Service.Dtos.Courses;
using TimEduIT.Service.Interfaces.Common;
using TimEduIT.Service.Interfaces.Courses;
using static Dapper.SqlMapper;

namespace TimEduIT.Service.Service.Courses;

public class CoursesCervice :BaseRepository, ICoursesService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IFileService _fileService;
    public CoursesCervice(ICourseRepository courseRepository, IFileService fileService)
    {
        _courseRepository = courseRepository;
        _fileService = fileService;
    }
    public async Task<long> CountAsync() => await _courseRepository.CountAsync();


    public async Task<bool> CreateAsync(CourseCreateDto dto)
    {
        string imagepath = await _fileService.UploadImageAsync(dto.Image);
        Course course = new Course()
        {
            ImagePath = imagepath,
            CourseName = dto.CourseName,
            CategoriesId=dto.CategoryId,
            Description = dto.Description,
            Price = float.Parse(dto.Price.ToString()),
            InstructorName = dto.InstructorName,

            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _courseRepository.CreateAsync(course);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long Id)
    {
        var course = await _courseRepository.GetByIdAsync(Id);
        if (course is null) throw new CoursesNotFoundException();

        var result = await _fileService.DeleteImageAsync(course.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _courseRepository.DeleteAsync(Id);
        return dbResult > 0;
    }  

    public async Task<bool> UpdateAsync(long Id, CoursesUpdateDto dto)
    {
        var course = await _courseRepository.GetByIdAsync(Id);
        if (course is null) throw new CoursesNotFoundException();

        course.CourseName = dto.Name;
        course.Description = dto.Description;

        if (dto.Image is not null)
        {
            var deleteResult = await _fileService.DeleteImageAsync(course.ImagePath);
            //if (deleteResult is false) throw new ImageNotFoundException();

            string newImagePath = await _fileService.UploadImageAsync(dto.Image);

            course.ImagePath = newImagePath;
        }

        course.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _courseRepository.UpdateAsync(Id, course);
        return dbResult > 0;
    }


    public async Task<Course> GetByIdAsync(long Id)
    {
        var course = await _courseRepository.GetByIdAsync(Id);
        if (course is null) throw new CoursesNotFoundException();
        else return course;
    }

    public async Task<IList<CoursesViewModel>> GetAllAsync(PaginationParams @params)
    {
        var course = await _courseRepository.GetAllAsync(@params);
        return course;

    }
}
