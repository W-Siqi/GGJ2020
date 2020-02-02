using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorHandDisplayer : CharacterBodyDisplayer
{
    public SpriteRenderer handsupRenderer;
    public override void UpdateAccrodingTo(CharacterDrawer.BodyState bodyState)
    {
        var isActivated = bodyState.hasHands;


        if (bodyState.hasHands)
        {
            if (bodyState.hasHead)
            {
                // hands up 
                handsupRenderer.enabled = true;
                bodyRenderer.enabled = false;
            }
            else
            {
                // normal hand
                handsupRenderer.enabled = false;
                bodyRenderer.enabled = true;
            }
        }
        else {
            // no hands
            var hasHandsPrevious = handsupRenderer.enabled || bodyRenderer.enabled;
            if (hasHandsPrevious) {
                OnPaintCanceled();
            }
            handsupRenderer.enabled = false;
            bodyRenderer.enabled = false;
        }

        if (spwanTag)
            spwanTag.enabled = isActivated;
        else
            Debug.LogError("component missing");
    }
}
