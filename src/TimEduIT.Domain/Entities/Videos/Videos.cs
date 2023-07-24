﻿namespace TimEduIT.Domain.Entities.Videos;

public class Videos : Auditable
{
    public long CoursesId { get; set; }

    public string Description { get; set; } = string.Empty;

    public string VideoPath { get; set; } = string.Empty;

    public long CategoriesId { get; set; }
}
