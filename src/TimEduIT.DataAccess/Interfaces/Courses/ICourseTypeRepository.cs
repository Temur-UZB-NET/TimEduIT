using TimEduIT.DataAccess.Common.Interfaces;
using TimEduIT.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.DataAccess.ViewModels.Courses;
using TimEduIT.Domain.Entities.Courses;

namespace TimEduIT.DataAccess.Interfaces.Courses;   

public interface ICourseTypeRepository : IRepository<Course,CoursesViewModel> ,IGetAll<CoursesViewModel>,ISearchable<CoursesViewModel>
{
}
