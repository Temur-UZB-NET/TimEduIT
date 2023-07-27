using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.DataAccess.Interfaces.Videos;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Domain.Entities.Videos;

namespace TimEduIT.DataAccess.Repositories.Videos;

public class VideosRepository : BaseRepository, IVideoRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) from videos";
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

    public async Task<int> CreateAsync(VideoModel entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO videos ( courses_id, description, video_path, categories_id, created_at, updated_at) " +
                "VALUES (@CoursesId, @Description, @VideoPath, @CategoriesId, @CreatedAt, @UpdatedAt);";
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
            string query = $"delete from videos where id = @Id";
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

    public async Task<IList<VideoModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from videos " +
                $"order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<VideoModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<VideoModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<VideoModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from videos where id = {id}";
            var result = await _connection.QuerySingleAsync<VideoModel>(query);
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

    public async Task<(int ItemsCount, IList<VideoModel>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select *from videos where name ilike '%@Search%' order by id desc " +
                        $" offset {@params.GetSkipCount()} limit {@params.PageSize};";
            var result = (await _connection.QueryAsync<VideoModel>(query, new { Search = search })).ToList();

            return (result.Count(), result);
        }
        catch
        {
            return (0, new List<VideoModel>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, VideoModel entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE videos SET " +
                "courses_id = @CoursesId, description = @Description, video_path = @VideoPath," +
                " categories_id = @CategoriesId, created_at = @CreatedAt, updated_at = @UpdatedAt" +
                $" WHERE id={id};";
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
