using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionPoint : MonoBehaviour
{
    private const float SMALL_VISION_RADIUS = 1f;
    private const float LARGE_VISION_RADIUS = 10f;

    public enum VisionScope { small, large}

    void Start()
    {
        SetVision(VisionScope.small);
    }

    public void SetVision(VisionScope visionScope) {
        float radius = SMALL_VISION_RADIUS;
        switch (visionScope) {
            case VisionScope.small:
                radius = SMALL_VISION_RADIUS;
                break;
            case VisionScope.large:
                radius = LARGE_VISION_RADIUS;
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
}
