using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModApplier : MonoBehaviour
{
    public static ModApplier instance = null;

    public bool isModed = false;
    public Sprite headSprite = null;
    private void Start()
    {
        instance = this;

        var archive = ModArchive.ReadArchive();
        if (archive.choosedHeadImagePath != "" && archive.choosedHeadImagePath!= ModArchive.DEFAUT_IMG_PATH)
        {
            isModed = true;
        }
        else {
            isModed = false;
        }

        StartCoroutine(LoadSprite(archive.choosedHeadImagePath));
    }

    IEnumerator LoadSprite(string path)
    {
        WWW www = new WWW("file://" + path);
        yield return www;
        if (www.isDone)
        {
            var tex = www.texture;
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            headSprite = sprite;
        }
    }
}
