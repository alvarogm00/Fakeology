using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    private void Start()
    {
        AudioManager.instance.MusicVolume = 1;
        AudioManager.instance.PlayBackgroundMusic(AppAudio.MUSIC_MENU);
    }

    void Update()
    {
       if(Input.anyKeyDown)
       {
            ScenesManager.scene = AppScenes.SESION_MONKEY;
            ScenesManager.LoadingScene();
       }
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
