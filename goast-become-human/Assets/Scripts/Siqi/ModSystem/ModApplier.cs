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
        var headImg = Resources.Load<Texture2D>(archive.choosedHeadImagePath);
        if (headImg)
        {
            isModed = true;
            headSprite = Sprite.Create(headImg, new Rect(0, 0, headImg.width, headImg.height), new Vector2(0.5f, 0.5f));
        }
        else {
            isModed = false;
        }
    }
}
