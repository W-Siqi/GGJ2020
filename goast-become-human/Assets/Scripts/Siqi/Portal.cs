using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Portal : MonoBehaviour
{
    public Portal targetPortal = null;

    private Collider2D collider2D;
    private float lockTillTime = -1f;

    private void Start()
    {
        collider2D = GetComponent<Collider2D>();
    }

    public void Transport(PortalableObject target) {    
        LockPortal();
        // Debug.Log(gameObject.name + " transport");
        var targetPos = transform.position;
        targetPos.z = LayerZ.CHARACTER;
        target.transform.position = targetPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(gameObject.name + "trigger enter");
        if (Time.time > lockTillTime)
        {
            var portableTarget = collision.gameObject.GetComponent<PortalableObject>();
            if (portableTarget)
                targetPortal.Transport(portableTarget);
        }
    }

    private void LockPortal() {
        float LOCK_TIME = 2f;
        lockTillTime = Time.time + LOCK_TIME;
    }
}
