using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModableHeadImg : ModableBehaviour
{
    public SpriteRenderer spriteRenderer;

    IEnumerator Start()
    {
        // wait for the mod resource to load 
        yield return new WaitForSeconds(2f);

        var modApplier = ModApplier.instance;
        if (modApplier && modApplier.isModed && modApplier.headSprite != null) {
            spriteRenderer.sprite = modApplier.headSprite;
        }
    }
}
