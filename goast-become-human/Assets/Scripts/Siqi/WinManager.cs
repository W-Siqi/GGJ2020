using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static  WinManager instance = null;

    public string winSceneName = "WinScene";
    private bool winReady = false;

    private void Start()
    {
        instance = this;
    }

    public void TriggerWin(WinSceneConditionHandle.WinPlayer winPlayer)
    {
        if (!winReady) {
            winReady = true;
            WinSceneConditionHandle.SetHandle(winPlayer);
            StartCoroutine(WinSceneTransferAfter(3f));
        }

    }

    IEnumerator WinSceneTransferAfter(float seconds) {
        yield return new WaitForSeconds(seconds);
        UnityEngine.SceneManagement.SceneManager.LoadScene(winSceneName);
    }
}
