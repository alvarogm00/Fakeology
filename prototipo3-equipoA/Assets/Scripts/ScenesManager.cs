using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : PersistenSingleton<ScenesManager>
{
    public static string scene;
    public static void LoadingScene()
    {
        SceneManager.LoadScene(AppScenes.SCENE_TRANSITION);
    }
}
