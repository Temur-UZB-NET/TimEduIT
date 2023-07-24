namespace TimEduIT.Domain.Exceptions.Video;

internal class VideoNotFoundException : NotFoundException
{
    public VideoNotFoundException()
    {
        this.TitleMessage = "Video not found";
    }
}
