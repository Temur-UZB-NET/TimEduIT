using TimEduIT.DataAccess.Common.Interfaces;
using TimEduIT.Domain.Entities.Videos;

namespace TimEduIT.DataAccess.Interfaces.Videos;

public interface IVideoRepository : IRepository<VideoModel, VideoModel>, IGetAll<VideoModel>, ISearchable<VideoModel>
{
}
