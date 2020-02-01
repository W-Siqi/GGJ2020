using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBodyDisplayer : MonoBehaviour
{
    public enum BodyType {
        hand,leg,chest,head,heart
    }

    public BodyType type;
    public SpriteRenderer bodyRenderer;

    public void UpdateAccrodingTo(CharacterDrawer.BodyState bodyState)
    {
        bool isActivated = false;

        switch (type) {
            case BodyType.hand:
                isActivated = bodyState.hasHands;
                break;
            case BodyType.chest:
                isActivated = bodyState.hasChest;
                break;
            case BodyType.leg:
                isActivated = bodyState.hasLegs;
                break;
            case BodyType.heart:
                isActivated = bodyState.hasHeart;
                break;
            case BodyType.head:
                isActivated = bodyState.hasHead;
                break;
        }

        if (bodyRenderer)
            bodyRenderer.enabled = isActivated;
        else
            Debug.LogError("prefab missing");
    }
}
