using TimEduIT.DataAccess.Interfaces.Courses;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Domain.Entities.Courses;
using TimEduIT.Service.Dtos.Courses;
using TimEduIT.Service.Interfaces.Courses;

namespace TimEduIT.Service.Service.Courses;

public class CoursesCervice : ICoursesService
{
    private readonly ICourseRepository _courseRepository;

    public CoursesCervice(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();

    }

    public Task<bool> CreateAsync(CourseCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long TypeId)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Course>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Course> GetByIdAsync(long TypeId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long TypeId, CoursesUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
