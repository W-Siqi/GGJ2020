using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class ModArchive
{
    public const string DEFAUT_IMG_PATH = "dft";

    private static ModArchive instance = null;

    public string choosedHeadImagePath = "";
    public List<string> headImagePaths = new List<string>();
    public int nameCounter = 0;

    public static ModArchive ReadArchive() {
        if (instance != null)
            return instance;

        var archive = ModResourceManager.LoadModArchive();
        if (archive == null)
        {
            Debug.LogError("archive miss");
            return null;
        }
        else {
            instance = archive;
            return archive;
        }
    }

    public void Save() {
        ModResourceManager.ApplyArchive(this);
    }
}
