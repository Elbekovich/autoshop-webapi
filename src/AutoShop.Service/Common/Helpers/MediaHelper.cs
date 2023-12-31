﻿namespace AutoShop.Service.Common.Helpers;

public class MediaHelper
{
    public static string MakeImagName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid() + extension;
        return name;
    }

    public static string[] GetImageExtensions()
    {
        return new string[]
        {
            // JPG files
            ".jpg", ".jpeg",
            // Png files
            ".png",
            // Bmp files
            ".bmp",
            // Heic files (iphone)
            ".heic"
        };
    }
}
