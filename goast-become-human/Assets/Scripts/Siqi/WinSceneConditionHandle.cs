using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneConditionHandle : MonoBehaviour
{
    public enum WinPlayer { player1,player2}
    [SerializeField]
    private WinPlayer winPlayer;

    public static void SetHandle(WinPlayer winPlayer) {
        var GO = new GameObject();
        var handle = GO.AddComponent<WinSceneConditionHandle>();
        handle.winPlayer = winPlayer;
        DontDestroyOnLoad(GO);
    }
    public static WinPlayer ReadHandleAndDestroy() {
        var winPlayer = WinPlayer.player1;

        var instance =  FindObjectOfType<WinSceneConditionHandle>();
        if (instance) {
            winPlayer = instance.winPlayer;
            Destroy(instance.gameObject, 1f);
        }

        return winPlayer;
    }      
}
