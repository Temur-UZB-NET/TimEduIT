using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimEduIT.Service.Interfaces.Common;

public interface IVideoProtsesService
{
    public Task<string?> VideoUploadAsync(IFormFile video);

    public Task<bool> VideoDeleteAsync(string subPath);
}
