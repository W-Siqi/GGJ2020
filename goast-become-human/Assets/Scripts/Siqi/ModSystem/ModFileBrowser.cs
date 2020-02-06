using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ModFileBrowser : MonoBehaviour
{
    public Texture2D file, folder, back, drive;
    public string saveDirectory = "MOD";
    FileBrowser fb = new FileBrowser();
    string output = "no file";

    private bool browserOn = false;

    public void OpenBrowser()
    {
        browserOn = true;
    }

    // Use this for initialization
    void Start()
    {
        fb.fileTexture = file;
        fb.directoryTexture = folder;
        fb.backTexture = back;
        fb.driveTexture = drive;
        //show the search bar
        fb.showSearch = true;
        //search recursively (setting recursive search may cause a long delay)
        fb.searchRecursively = true;
        Debug.Log(Application.dataPath);
    }

    void OnGUI()
    {
        // only draw when browser is on
        if (!browserOn)
            return;

        if (fb.draw())
        { //true is returned when a file has been selected
          //the output file is a member if the FileInfo class, if cancel was selected the value is null
            output = (fb.outputFile == null) ? "cancel hit" : fb.outputFile.ToString();
            Debug.Log("file :" + output);
            ImportImageFrom(output);
        }
    }

    void ImportImageFrom(string path)
    {
        StartCoroutine(GetTexture(path));
    }

    IEnumerator GetTexture(string url)
    {
        WWW www = new WWW("file://" + url); 
        yield return www;
        if (www.isDone)
        {
            var img = www.texture;
           
            var savedPath = ModResourceManager.SaveImage(img);

            var archive = ModArchive.ReadArchive();
            archive.headImagePaths.Add(savedPath);

            // close the browser when it is done
            browserOn = false;

            // need refresh
            ModEditor.instance.RefreshModWindow();
        }
    }
}
