using Microsoft.AspNetCore.Http;

namespace AutoShop.Service.Interfaces.Common;

public interface IFileService
{
    //return sup path of this image
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<bool> DeleteImageAsync(string subpath);

    public Task<string> UploadAvatarAsync(IFormFile avatar);

    public Task<bool> DeleteAvatarAsync(string subpath);
}
