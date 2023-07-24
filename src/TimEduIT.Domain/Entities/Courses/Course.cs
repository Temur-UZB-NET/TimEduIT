namespace TimEduIT.Domain.Entities.Courses;

public class Course : Auditable
{
    public string ImagePath { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;

    public string InstructorName { get; set; } = string.Empty;

    public float Price { get; set; }

    public long CategoriesId { get; set; }

}
