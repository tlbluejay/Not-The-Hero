using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad;
    public string sceneToUnload;

    public void ChangeToScene()
    {
        StartCoroutine(LoadYourAsyncScene(sceneToLoad));
        StartCoroutine(UnloadYourAsyncScene(sceneToUnload));
    }

    private IEnumerator LoadYourAsyncScene(string sceneToLoad)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private IEnumerator UnloadYourAsyncScene(string sceneToUnload)
    {
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync(sceneToUnload);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
