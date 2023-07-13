using AutoShop.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using AutoShop.Service.Common.Helpers;

namespace AutoShop.Service.Services.Common;
public class FileService : IFileService
{
    private readonly string MEDIA = "media";
    private readonly string IMAGES = "images";
    private readonly string AVATARS = "avatars";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)         
    {
        ROOTPATH = env.WebRootPath;
    }

    public Task<bool> DeleteAvatarAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteImageAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }

    public Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        throw new NotImplementedException();
    }
    public async Task<string> UploadImageAsync(IFormFile image)
    {
        //string newImageName = MediaHelper.MakeImagName(image.FileName);
        //string subpath = Path.Combine(MEDIA, IMAGES, newImageName);
        //string path = Path.Combine(ROOTPATH, subpath);

        //Directory.CreateDirectory(Path.GetDirectoryName(path)); // Create directories if they don't exist

        //using (var stream = new FileStream(path, FileMode.Create))
        //{
        //    await image.CopyToAsync(stream);
        //}

        //return subpath;
        string newImageName = MediaHelper.MakeImagName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGES, newImageName);
        string path = Path.Combine(ROOTPATH, subpath);
        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();
        return subpath;
    }
}
