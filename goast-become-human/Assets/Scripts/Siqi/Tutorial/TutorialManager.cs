using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public string sceneName = "FinalScene";
    public TutorialFinishTrriger[] finishTrrigers;

    // Start is called before the first frame update
    void Start()
    {
        finishTrrigers = FindObjectsOfType<TutorialFinishTrriger>();
        StartCoroutine(TutorialEndCheck());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator TutorialEndCheck() {
        yield return null;
        while (true) {
            var finished = true;
            foreach (var tri in finishTrrigers) {
                if (!tri.isReady)
                    finished = false;
            }

            if (finished)
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
