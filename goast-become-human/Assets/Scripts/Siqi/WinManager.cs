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

    public void TriggerWin()
    {
        if (!winReady) {
            winReady = true;
            StartCoroutine(WinSceneTransferAfter(3f));
        }

    }

    IEnumerator WinSceneTransferAfter(float seconds) {
        yield return new WaitForSeconds(seconds);
        UnityEngine.SceneManagement.SceneManager.LoadScene(winSceneName);
    }
}
