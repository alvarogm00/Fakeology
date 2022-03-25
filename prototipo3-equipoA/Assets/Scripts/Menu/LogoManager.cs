using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoManager : MonoBehaviour
{
    public AudioSource MusicIntro;

    // Update is called once per frame
    void Update()
    {
        if(MusicIntro.isPlaying == false)
        {
            ScenesManager.scene = AppScenes.CUT_SCENE;
            ScenesManager.LoadingScene();
        }
    }

}
