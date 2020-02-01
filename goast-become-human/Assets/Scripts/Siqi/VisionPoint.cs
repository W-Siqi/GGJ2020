using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionPoint : MonoBehaviour
{
    const float RADIUS_TO_METERS = 5f;

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

	public bool visionEnhanced{
		get;private set;
	}

	public bool IsWithinVision(Vector3 position) {
        position.z = transform.position.z;
        var distance = (position - transform.position).magnitude;

        if (visionEnhanced)
            return distance < largetVisionRadius * RADIUS_TO_METERS;
        else
            return distance < smallVisionRadius * RADIUS_TO_METERS;
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
		{
			visionEnhanced = true;
			SetVision(VisionScope.large);
		}
		else {
			visionEnhanced = false;
			SetVision(VisionScope.small);
		}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawSphere(transform.position, smallVisionRadius * RADIUS_TO_METERS);
    }
}
