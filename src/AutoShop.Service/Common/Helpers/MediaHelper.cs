namespace AutoShop.Service.Common.Helpers;

public class MediaHelper
{
    public static string MakeImagName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid() + extension;
        return name;
    }
}
