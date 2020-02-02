using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateMonitor : MonoBehaviour
{
    public CharacterInfo characterInfo;
    public WinSceneConditionHandle.WinPlayer player;

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
                WinManager.instance.TriggerWin(player);
                Destroy(this);
            }
        }
    }
}
