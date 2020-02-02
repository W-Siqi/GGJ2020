using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneManager : MonoBehaviour
{
    public string startSceneName = "StartScene";

    public GameObject player1Win;
    public GameObject player2Win;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        var winplayer = WinSceneConditionHandle.ReadHandleAndDestroy();
        if (winplayer == WinSceneConditionHandle.WinPlayer.player1)
        {
            player1Win.SetActive(true);
            player2Win.SetActive(false);
        }
        else {
            player1Win.SetActive(false);
            player2Win.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(startSceneName);
        }
    }
}
