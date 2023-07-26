using Dapper;
using TimEduIT.DataAccess.Interfaces.Courses;
using TimEduIT.DataAccess.Utils;
using TimEduIT.DataAccess.ViewModels.Courses;
using TimEduIT.Domain.Entities.Courses;

namespace TimEduIT.DataAccess.Repositories.Courses;

public class CoursesRepository : BaseRepository, ICourseRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from courses";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> CreateAsync(Course entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO courses(image_path, description, course_name, instructor_name, price, categories_id, created_at, updated_at) " +
                " VALUES(@ImagePath, @Description, @CourseName, @InstructorName, @Price, @CategoriesId, @CreatedAt, @UpdatedAt); ";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM courses WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<CoursesViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM courses order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<CoursesViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<CoursesViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Course?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM courses where id = @Id ; ";
            var result = await _connection.QuerySingleAsync<Course>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }



    public Task<(int ItemsCount, IList<CoursesViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Course entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE courses SET image_path = @Image_path, description = @Description, course_name = @Course_name, " +
                $"instructor_name = @Instructor_name, price = @Price, categories_id = @Categories_id, " +
                $"created_at = @Created_at, updated_at = @Updated_at" +
                $"WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
