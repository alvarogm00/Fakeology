using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    string sceneName;
    void OnEnable()
    {
        sceneName = ScenesManager.scene;
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForEndOfFrame();
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += FinishLoading;
    }

    void FinishLoading(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= FinishLoading;
        Destroy(this.gameObject);
    }
}
