using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private int sceneCount;

    private void Awake()
    {
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }
    public async void LoadNextScene()
    {
        Debug.Log("TryLoad");
        var index = SceneManager.GetActiveScene().buildIndex;

        if (index >= sceneCount - 1)
        {
            await SceneManager.LoadSceneAsync(0, LoadSceneMode.Single); // better to do levels with prefabs
            return;
        }

        if (SceneManager.GetActiveScene().buildIndex < sceneCount)
        {
            await SceneManager.LoadSceneAsync(index + 1, LoadSceneMode.Single);
            return;
        }
    }
    public void RestartScene()
    {
        Debug.Log("TryRestart");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
