using TimEduIT.DataAccess.Utils;
using TimEduIT.DataAccess.ViewModels.Courses;
using TimEduIT.Domain.Entities.Courses;
using TimEduIT.Service.Dtos.Courses;

namespace TimEduIT.Service.Interfaces.Courses;

public interface ICoursesService
{
    public Task<bool> CreateAsync(CourseCreateDto dto);

    public Task<bool> DeleteAsync(long TypeId);

    public Task<long> CountAsync();

    public Task<IList<CoursesViewModel>> GetAllAsync(PaginationParams @params);

    public Task<Course> GetByIdAsync(long TypeId);

    public Task<bool> UpdateAsync(long TypeId, CoursesUpdateDto dto);
}
