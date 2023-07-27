using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.DataAccess.Utils;
using TimEduIT.Service.Dtos.Videos;

namespace TimEduIT.Service.Interfaces.Videos;

public interface IVideoService
{
    public Task<bool> CreateAsync(VideoCreateDto dto);

    public Task<bool> DeleteAsync(long videoId);

    public Task<long> CountAsync();

    public Task<IList<Video>> GetAllAsync(PaginationParams @params);

    public Task<Video> GetByIdAsync(long videoId);

    public Task<bool> UpdateAsync(long videoId, VideoUpdateDto dto);
}
