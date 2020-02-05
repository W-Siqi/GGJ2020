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
        var img = Resources.Load<Texture2D>(path);
        var sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));

        pathOfImage = path;
        image.sprite = sprite;

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
}
