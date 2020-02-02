using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateMonitor : MonoBehaviour
{
    public CharacterInfo characterInfo;

    private void Update()
    {
        if (characterInfo) {
            var isFullBody = characterInfo.hasHead &&
           characterInfo.hasHands &&
           characterInfo.hasChest &&
           characterInfo.hasLegs &&
           characterInfo.hasHeart;

            if (isFullBody) {
                Debug.Log("win invoke!");
                WinManager.instance.TriggerWin();
                Destroy(this);
            }
        }
    }
}
