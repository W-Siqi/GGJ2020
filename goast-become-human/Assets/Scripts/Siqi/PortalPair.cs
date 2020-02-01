using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalPair : MonoBehaviour
{
    public float showUpTime = 2f;
    public Vector2 sleepTime = new Vector2(5f, 15f);
    public Vector2 startBias = new Vector2(0f, 10f);
    public Portal portalA;
    public Portal portalB;

    void Start() {
        PortalClose();
        StartCoroutine(Ticking());
    }

    IEnumerator Ticking() {
        var firstShowTime = Random.Range(startBias.x, startBias.y);
        yield return new WaitForSeconds(firstShowTime);

        while (true) {
            PortalOpen();
            yield return new WaitForSeconds(showUpTime);
            PortalClose();

            var sleep = Random.Range(sleepTime.x, sleepTime.y);
            yield return new WaitForSeconds(sleep);
        }
    }

    void PortalOpen() {
        if (portalA)
            portalA.enabled = true;
        if(portalB)
            portalB.enabled = true;
    }

    void PortalClose() {
        if (portalA)
            portalA.enabled = false;
        if (portalB)
            portalB.enabled = false;
    }
}
