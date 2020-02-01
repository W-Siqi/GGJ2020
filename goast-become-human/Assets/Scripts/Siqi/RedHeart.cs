using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHeart : Heart
{
    protected override void OnPicked()
    {
        throw new System.NotImplementedException();
    }

    [SerializeField]
    private Color hiddenColor;
    [SerializeField]
    private Color realColor;
    [SerializeField]
    private SpriteRenderer heartRenderer;

    private VisionPoint[] monitoredVisionPoints;

    private void Start()
    {
        monitoredVisionPoints = FindObjectsOfType<VisionPoint>();
    }

    private void Update()
    {
        if (isSeen)
        {
            heartRenderer.color = realColor;
        }
        else
        {
            heartRenderer.color = hiddenColor;
        }
    }

    private bool isSeen{
        get {
            foreach (var vision in monitoredVisionPoints) {
                if (vision.visionEnhanced && vision.IsWithinVision(transform.position))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
