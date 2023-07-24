namespace TimEduIT.Domain.Exceptions.Courses;

public class CoursesNotFoundException : NotFoundException
{
    public CoursesNotFoundException()
    {
        this.TitleMessage = "Contacts Not found Exseption";
    }
}
