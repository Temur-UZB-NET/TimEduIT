using Microsoft.AspNetCore.Http;

namespace TimEduIT.Service.Dtos.Categories;

public class CategoryCreatDto
{
    public string Name { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public IFormFile Image { get; set; } = default!; 
}
