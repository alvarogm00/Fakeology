using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouLostSceneManager : MonoBehaviour
{
    public void OnButton()
    {
        AudioManager.instance.PlaySound(AppAudio.BUTTON_NORMAL_SFX);
        ScenesManager.scene = AppScenes.MENU_SCENE;
        ScenesManager.LoadingScene();
    }
}
