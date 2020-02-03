using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModableHeadImg : ModableBehaviour
{
    public SpriteRenderer spriteRenderer;

    IEnumerator Start()
    {
        yield return null;
        var modApplier = ModApplier.instance;
        if (modApplier && modApplier.isModed) {
            spriteRenderer.sprite = modApplier.headSprite;
        }
    }
}
