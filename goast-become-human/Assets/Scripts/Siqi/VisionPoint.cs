using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionPoint : MonoBehaviour
{
    public float smallVisionRadius = 1f;
    public float largetVisionRadius = 10f;
    public CharacterInfo characterInfo;

    public enum VisionScope { small, large}

    void Start()
    {
        SetVision(VisionScope.small);
    }

    void Update()
    {
        UpdateVisionStateTo(characterInfo);
    }

    public void SetVision(VisionScope visionScope) {
        float radius = smallVisionRadius;
        switch (visionScope) {
            case VisionScope.small:
                radius = smallVisionRadius;
                break;
            case VisionScope.large:
                radius = largetVisionRadius;
                break;
            default:
                Debug.LogError("wrong enum");
                break;
        }

        var newScale = transform.localScale;
        newScale.x = radius;
        newScale.y = radius;
        transform.localScale = newScale;
    }

    void UpdateVisionStateTo(CharacterInfo characterInfo) {
        if (characterInfo.hasHead)
            SetVision(VisionScope.large);
        else
            SetVision(VisionScope.small);
    }
}
