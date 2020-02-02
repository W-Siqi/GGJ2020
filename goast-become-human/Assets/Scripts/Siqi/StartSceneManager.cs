using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
    public string totorialScene = "Tutorial";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GoToTutorial();
    }

    public void GoToTutorial()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(totorialScene);
    }
}
