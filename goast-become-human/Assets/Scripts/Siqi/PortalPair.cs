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
        Debug.Log("portal open");
        if (portalA)
            portalA.gameObject.SetActive(true);
        if(portalB)
            portalB.gameObject.SetActive(true);
    }

    void PortalClose() {
        Debug.Log("portal close");
        if (portalA)
            portalA.gameObject.SetActive(false);
        if (portalB)
            portalB.gameObject.SetActive(false);
    }
}
