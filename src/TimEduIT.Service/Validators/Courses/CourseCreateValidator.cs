using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.Service.Common.Helpers;
using TimEduIT.Service.Dtos.Courses;

namespace TimEduIT.Service.Validators.Courses;

public class CourseCreateValidator : AbstractValidator<CourseCreateDto>
{
    public CourseCreateValidator()
    {
        RuleFor(dto => dto.CourseName).NotNull().NotEmpty().WithMessage("Name field is required!");
        RuleFor(dto => dto.Description).NotNull().NotEmpty().WithMessage("Description field is required!");

        int maxImageSizeMB = 5;
        RuleFor(dto => dto.Image).NotEmpty().NotNull().WithMessage("Image field is required");
        RuleFor(dto => dto.Image.Length).LessThan(maxImageSizeMB * 1024 * 1024 + 1).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
        RuleFor(dto => dto.Image.FileName).Must(predicate =>
        {
            FileInfo fileInfo = new FileInfo(predicate);
            return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
        }).WithMessage("This file type is not image file");
    }
}
