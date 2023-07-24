using TimEduIT.DataAccess.Common.Interfaces;
using TimEduIT.DataAccess.Interfaces;
using TimEduIT.DataAccess.ViewModels.Courses;
using TimEduIT.Domain.Entities.Courses;

namespace TimEduIT.DataAccess.Interfaces.Courses;

public interface ICourseRepository : IRepository<Course,CoursesViewModel>,IGetAll<CoursesViewModel>,ISearchable<CoursesViewModel>
{
}
