using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimEduIT.Service.Dtos.Courses;

public class CourseCreateDto
{
    public string CourseName { get; set; } = string.Empty;

    public string Description { get; set; } = String.Empty;

    public string InstructorName { get; set; } = string.Empty;

    public double Price { get; set; }

    public long CategoryId { get; set; }

    public IFormFile Image { get; set; } = default!;

}
