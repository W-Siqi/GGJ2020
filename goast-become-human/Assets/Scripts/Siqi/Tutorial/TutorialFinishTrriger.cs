using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFinishTrriger : MonoBehaviour
{
    public bool isReady = false;
	public string triggerTag = "player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == triggerTag) {
            isReady = true;
        }
    }
}
