using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimEduIT.Service.Common.Helpers;
using TimEduIT.Service.Dtos.Courses;

namespace TimEduIT.Service.Validators.Courses;

public class CoursesUpdateValidator : AbstractValidator<CoursesUpdateDto>
{
    public CoursesUpdateValidator()
    {
        RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Name field is required!");

        When(dto => dto.Image is not null, () =>
        {
            int maxImageSizeMB = 5;
            RuleFor(dto => dto.Image!.Length).LessThan(maxImageSizeMB * 1024 * 1024).WithMessage($"Image size must be less than {maxImageSizeMB} MB");
            RuleFor(dto => dto.Image!.FileName).Must(predicate =>
            {
                FileInfo fileInfo = new FileInfo(predicate);
                return MediaHelper.GetImageExtensions().Contains(fileInfo.Extension);
            }).WithMessage("This file type is not image file");
        });
    }
}
