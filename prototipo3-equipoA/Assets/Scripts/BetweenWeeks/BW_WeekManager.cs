using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class BW_WeekManager : TemporalSingleton<BW_WeekManager>
{
    public Button m_botonConfirmacion;

    private enum OrcSceneToLoad { Orcs1, Orcs2, Orcs3}
    [SerializeField] OrcSceneToLoad orcSceneToLoad;

    [HideInInspector] public int m_numeroPossitsSemana;
    [HideInInspector] public int m_numeroDeAciertos; //Guarda los aciertos (entre 0 y 7).

    [SerializeField] Image suspicionBar;

    void Start()
    {
        m_botonConfirmacion.interactable = false; //este boton se activará si la semana esta llena.

        AudioManager.instance.PlayBackgroundMusic(AppAudio.MUSIC_BETWEEN_WEEKS);
        suspicionBar.transform.localScale = new Vector2(SaveVariables.instance.Suspicion / 100, 1);
    }

    public void AñadirPossitSemana(bool añadir) //Cuenta si hay un possit por cada dia para activar el boton de confirmar.
    {
        if (añadir)
        {
            m_numeroPossitsSemana++;
        }
        else
        {
            m_numeroPossitsSemana--;
        }
        

        if (m_numeroPossitsSemana >= 7)
        {
            m_botonConfirmacion.interactable = true; //Se activa el boton de confirmar.
        }
        else
        {
            m_botonConfirmacion.interactable = false; //Se desactiva el boton de confirmar.
        }
    }

    public void CheckIfCalendarCorrect() //Revisa aciertos y suma sospecha.
    {
        if (m_numeroDeAciertos == 0)
        {
            SaveVariables.instance.Suspicion += 40;
        }
        else if (m_numeroDeAciertos == 1)
        {
            SaveVariables.instance.Suspicion += 30;
        }
        else if (m_numeroDeAciertos == 2)
        {
            SaveVariables.instance.Suspicion += 20;
        }
        else if (m_numeroDeAciertos == 3)
        {
            SaveVariables.instance.Suspicion += 10;
        }
        else if (m_numeroDeAciertos == 4)
        {
            SaveVariables.instance.Suspicion += 5;
        }
        else if (m_numeroDeAciertos == 5)
        {
            SaveVariables.instance.Suspicion -= 5;
        }
        else if (m_numeroDeAciertos == 6)
        {
            SaveVariables.instance.Suspicion -= 10;
        }
        else if (m_numeroDeAciertos == 7)
        {
            SaveVariables.instance.Suspicion -= 20;
        }
    }

    public void OnExitButton()
    {
        AudioManager.instance.PlaySound(AppAudio.BUTTON_NORMAL_SFX);
        ScenesManager.scene = AppScenes.MENU_SCENE;
        ScenesManager.LoadingScene();
    }

    public void OnConfirmButton()
    {
        CheckIfCalendarCorrect();
        AudioManager.instance.PlaySound(AppAudio.BUTTON_CONFIRM_WEEK_SFX);

        print(SaveVariables.instance.Suspicion);
        StartCoroutine(ShowSuspicion());
    }

    public void OnContinueButton()
    {
        //Cargar escena pertienente.
        if(orcSceneToLoad == OrcSceneToLoad.Orcs1)
        {
            ScenesManager.scene = AppScenes.SESION_ORC_1;
        }
        else if (orcSceneToLoad == OrcSceneToLoad.Orcs2)
        {
            ScenesManager.scene = AppScenes.SESION_ORC_2;
        }
        else if (orcSceneToLoad == OrcSceneToLoad.Orcs3)
        {
            ScenesManager.scene = AppScenes.SESION_ORC_3;
        }
        ScenesManager.LoadingScene();
    }

    IEnumerator ShowSuspicion()
    {
        yield return new WaitForSeconds(1.5f);
        suspicionBar.transform.localScale = new Vector2(SaveVariables.instance.Suspicion / 100, 1);
    }
}
