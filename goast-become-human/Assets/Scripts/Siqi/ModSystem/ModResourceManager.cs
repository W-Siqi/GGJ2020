using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModResourceManager
{
    private const string MODDirectory = "/MOD";
    private const int TEX_SIZE = 256;

    /// <summary>
    /// return the path
    /// </summary>
    /// <returns></returns>
    public static string SaveImage(Texture2D texture) {
        var scaled = ScaleTexture(texture, TEX_SIZE, TEX_SIZE);
        var archive = ModArchive.ReadArchive();
        var savename = string.Format("{0}.png", archive.nameCounter++);
        var savePath = string.Format("{0}/{1}", GetMODDirectory(), savename);
        System.IO.File.WriteAllBytes(savePath, scaled.EncodeToPNG());
        return savePath;
    }

    private static Texture2D ScaleTexture(Texture2D source, int targetWidth, int targetHeight)
    {
        Texture2D result = new Texture2D(targetWidth, targetHeight, source.format, false);
        float incX = (1.0f / (float)targetWidth);
        float incY = (1.0f / (float)targetHeight);
        for (int i = 0; i < result.height; ++i)
        {
            for (int j = 0; j < result.width; ++j)
            {
                Color newColor = source.GetPixelBilinear((float)j / (float)result.width, (float)i / (float)result.height);
                result.SetPixel(j, i, newColor);
            }
        }
        result.Apply();
        return result;
    }

    private static string GetMODDirectory() {
        var dir = Application.dataPath + MODDirectory;
        if (!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }

        return dir;
    }
}
