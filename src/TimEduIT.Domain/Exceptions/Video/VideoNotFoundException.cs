namespace TimEduIT.Domain.Exceptions.Video;

public class VideoNotFoundException : NotFoundException
{
    public VideoNotFoundException()
    {
        this.TitleMessage = "Video not found";
    }
}
