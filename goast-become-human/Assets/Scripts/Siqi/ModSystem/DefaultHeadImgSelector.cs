using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultHeadImgSelector : MonoBehaviour
{
    [SerializeField]
    private Image selectedIndicator = null;
    public void SetSelected(bool isNowSelected)
    {
        if (isNowSelected)
        {
            selectedIndicator.enabled = true;
        }
        else
        {
            selectedIndicator.enabled = false;
        }
    }

    public void OnHeadImgSelected()
    {
        ModEditor.instance.OnHeadImgSelected(ModArchive.DEFAUT_IMG_PATH);
    }
}
