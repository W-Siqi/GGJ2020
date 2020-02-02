using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBodyDisplayer : MonoBehaviour
{
    public enum BodyType {
        hand,leg,chest,head,heart,sword,gun
    }

    public BodyType type;
    public SpriteRenderer bodyRenderer;

    private SpwanObjectTag spwanTag = null;

    private void Start()
    {
        spwanTag = GetComponent<SpwanObjectTag>();
    }

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
            case BodyType.gun:
                isActivated = bodyState.hasGun;
                break;
            case BodyType.sword:
                isActivated = bodyState.hasSword;
                break;
        }

        if (bodyRenderer) {
            if (bodyRenderer.enabled == true && isActivated == false)
                OnPaintCanceled();

            bodyRenderer.enabled = isActivated;
        }
        else
            Debug.LogError("prefab missing");

        if (spwanTag)
            spwanTag.enabled = isActivated;
        else
            Debug.LogError("component missing");
    }

    protected virtual void OnPaintCanceled() {
        FlyBodyPartSpawner.SpawnFlyBodyPart(this);
    }
}
