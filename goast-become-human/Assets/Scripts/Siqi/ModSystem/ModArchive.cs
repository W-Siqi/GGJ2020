using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class ModArchive : ScriptableObject
{
    const string SAVE_PATH = "Assets/Resources/MOD/modArchive.asset";
    const string READ_PATH = "MOD/modArchive";

    private static ModArchive instance = null;

    public string choosedHeadImagePath = "";
    public List<string> headImagePaths = new List<string>();
    public int nameCounter = 0;

    public static ModArchive ReadArchive() {
        if (instance)
            return instance;

        var archive = Resources.Load<ModArchive>(READ_PATH);
        if (archive == null)
        {
            var newArchive = ScriptableObject.CreateInstance<ModArchive>();
            AssetDatabase.CreateAsset(newArchive, SAVE_PATH);
            instance = newArchive;
            return newArchive;
        }
        else {
            instance = archive;
            return archive;
        }
    }
}
