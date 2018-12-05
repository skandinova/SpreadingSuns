using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour {
    private static int lastPlayedScene = 2;

    public void LoadByIndex(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadGameOverMenuScene(int sceneIndex) {
        lastPlayedScene = sceneIndex;
        SceneManager.LoadScene(1);
    }

    public void LoadLastPlayedScene() {
        SceneManager.LoadScene(lastPlayedScene);
    }
}
