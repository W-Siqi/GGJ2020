using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadImgSelector : MonoBehaviour
{
    public Image image;
    public Image selectedIndicator;

    [SerializeField]
    private string pathOfImage = "";

    public void InitSelector(string path,bool isNowSelected) {
        pathOfImage = path;
        StartCoroutine(LoadSprite(path));

        if (isNowSelected)
        {
            selectedIndicator.enabled = true;
        }
        else {
            selectedIndicator.enabled = false;
        }
    }

    public void OnDeleteSelectedImage() {
        ModEditor.instance.OnDeleteHeadImage(pathOfImage);
    }

    public void OnHeadImgSelected() {
        ModEditor.instance.OnHeadImgSelected(pathOfImage);
    }

    IEnumerator LoadSprite(string path) {
        WWW www = new WWW("file://" + path);
        yield return www;
        if (www.isDone)
        {
            var tex = www.texture;
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            image.sprite = sprite;
        }
    }
}
