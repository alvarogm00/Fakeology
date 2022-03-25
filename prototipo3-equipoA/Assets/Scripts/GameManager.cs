using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool nodeEntered;
    public bool setTimer;
    public int numberOfChilds;
    public bool isLastNode;
    public bool betweenWeeks;

    bool showSuspicion;
    bool autoChoose;
    float maxPatience = 100;
    float currentPatience;
    float patienceLevel;
    float maxSuspicion = 100;
    float currentSuspicion;
    float maxTimeButton;
    float minTimeButton;
    float timer;
    float timerAutochoose;
    int controller;

    [SerializeField] Image patienceBar;
    [SerializeField] Image maxPaienceBar;
    [SerializeField] Image suspicionBar;
    [SerializeField] Image maxSuspicionBar;
    [SerializeField] TextMeshProUGUI feedbackText;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject options;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] enum Scene {Monke, Orc1, Orc2, Orc3, Felon1, Felon2, Felon3, DnD1, DnD2, DnD3, BTW1, BTW2, BTW3, VICTORIA, DERROTA};
    [SerializeField] Scene nextScene;
    public enum SceneType { Monke, Orc, Felon, Burro};
    public SceneType sceneType;
    DialogueViewer2 dViewer;

    Color color;
    Color color2;

    void Start()
    {
        if (!betweenWeeks)
        {
            dViewer = FindObjectOfType<DialogueViewer2>();
            feedbackText.gameObject.SetActive(false);
        }
        color = suspicionBar.GetComponent<Image>().color;
        color2 = maxSuspicionBar.GetComponent<Image>().color;
        currentPatience = maxPatience;
        patienceLevel = 2;
        minTimeButton = 1.5f;
        maxTimeButton = 4f;

        currentSuspicion = SaveVariables.instance.Suspicion;
        suspicionBar.transform.localScale = new Vector2(currentSuspicion / maxSuspicion, 1);

        color.a = 0;
        color2.a = 0;
        suspicionBar.GetComponent<Image>().color = color;
        maxSuspicionBar.GetComponent<Image>().color = color2;

        timer = Random.Range(minTimeButton, maxTimeButton);
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        options.SetActive(false);

        SetBackgroundMusic();
    }

    void Update()
    {
        if (nodeEntered)
        {
            foreach (Transform t in dViewer.parentOfResponses)
            {
                t.gameObject.SetActive(false);
            }

            controller = 0;
            setTimer = true;
            currentPatience = maxPatience;
            nodeEntered = false;
        }

        if (setTimer)
        {
            SetButtonsVoid();
        }

        DecreasePatience();
        ShowSuspicion();

        if (currentPatience <= 0)
        {
            autoChoose = true;
            patienceLevel += 3;
            minTimeButton -= 0.2f;
            maxTimeButton -= 0.4f;
            currentSuspicion += 25;
            
            int random = Random.Range(0, numberOfChilds);
            dViewer.parentOfResponses.GetChild(random).GetComponent<Button>().onClick.Invoke();
            feedbackText.text = "Has respondido: " + dViewer.parentOfResponses.GetChild(random).GetComponentInChildren<TextMeshProUGUI>().text;
            feedbackText.gameObject.SetActive(true);
            timerAutochoose = 3;
        }

        if(currentSuspicion >= maxSuspicion)
        {
            ScenesManager.scene = AppScenes.SCENE_SOSPECHA_MAX;
            ScenesManager.LoadingScene();
        }

        if (autoChoose)
        {
            if (timerAutochoose > 0)
            {
                timerAutochoose -= Time.deltaTime;
            }
            else
                feedbackText.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }

    void ShowSuspicion()
    {
        if (showSuspicion)
        {
            color.a += Time.deltaTime;
            color2.a += Time.deltaTime;
            suspicionBar.GetComponent<Image>().color = color;
            maxSuspicionBar.GetComponent<Image>().color = color2;

            if (color.a >= 1)
            {
                showSuspicion = false;
            }
        }
        else if(!showSuspicion && color.a > 0)
        {
            color.a -= Time.deltaTime/4;
            color2.a -= Time.deltaTime/4;
            suspicionBar.GetComponent<Image>().color = color; 
            maxSuspicionBar.GetComponent<Image>().color = color2;

            suspicionBar.transform.localScale = new Vector2(currentSuspicion / maxSuspicion, 1);
        }
    }

    void DecreasePatience()
    {
        if (!isLastNode)
        {
            currentPatience -= patienceLevel * Time.deltaTime;
            patienceBar.transform.localScale = new Vector2(currentPatience / maxPatience, 1);
        }
        else
        {
            LastNode();
        }
    }

    public void AffectPatiene(bool good)
    {
        if (good)
        {
            if (!autoChoose)
            {
                patienceLevel -= 3;
                minTimeButton += 0.2f;
                maxTimeButton += 0.4f;
                if (currentSuspicion > 0)
                {
                    currentSuspicion -= 5;
                    showSuspicion = true;
                }
            }
            else
            {
                showSuspicion = true;
            }
        }
        else
        {
            patienceLevel += 3;
            minTimeButton -= 0.2f;
            maxTimeButton -= 0.4f;
            currentSuspicion += 10;
            showSuspicion = true;
        }

        patienceLevel = Mathf.Clamp(patienceLevel, 2, 32);
        minTimeButton = Mathf.Clamp(minTimeButton, 0, 1.5f);
        maxTimeButton = Mathf.Clamp(maxTimeButton, 2, 4f);
        currentSuspicion = Mathf.Clamp(currentSuspicion, 0, 100);
    }

    void SetButtonsVoid()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            dViewer.parentOfResponses.GetChild(controller).gameObject.SetActive(true);
            controller++;
            timer = Random.Range(minTimeButton, maxTimeButton);
        }

        if (controller >= numberOfChilds)
        {
            setTimer = false;
            if (controller > 3)
            {
                UnSetFirstButton();
            }
        }
    }

    void UnSetFirstButton()
    {
        dViewer.parentOfResponses.GetChild(0).gameObject.SetActive(false);
    }

    void LastNode()
    {
        Color colorPatience = patienceBar.GetComponent<Image>().color;
        Color colorPatience2 = maxPaienceBar.GetComponent<Image>().color;
        colorPatience.a = 0;
        colorPatience2.a = 0;
        patienceBar.GetComponent<Image>().color = colorPatience;
        maxPaienceBar.GetComponent<Image>().color = colorPatience2;

        SaveVariables.instance.Suspicion = currentSuspicion;
        StartCoroutine(LoadScene());
    }

    public void OnResume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void OnExit()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        ScenesManager.scene = AppScenes.MENU_SCENE;
        ScenesManager.LoadingScene();
    }

    public void OnOptions(bool isOptions)
    {
        pauseMenu.SetActive(!isOptions);
        options.SetActive(isOptions);

        if (!isOptions)
        {
            AudioManager.instance.MusicVolumeSave = musicSlider.value;
            AudioManager.instance.SfxVolumeSave = sfxSlider.value;
        }

        AudioManager.instance.PlaySound(AppAudio.BUTTON_NORMAL_SFX);
    }

    public void OnMusicValueChanged()
    {
        AudioManager.instance.MusicVolume = musicSlider.value;
    }

    public void OnSfxValueChanged()
    {
        AudioManager.instance.SfxVolume = sfxSlider.value;
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(10);
        LoadNextScene();
    }

    void SetBackgroundMusic()
    {
        if (sceneType == SceneType.Orc)
        {
            AudioManager.instance.PlayBackgroundMusic(AppAudio.MUSIC_ORCS);
        }
        else if (sceneType == SceneType.Felon)
        {
            AudioManager.instance.PlayBackgroundMusic(AppAudio.MUSIC_MUSKBOT);
        }
        else if (sceneType == SceneType.Burro)
        {
            AudioManager.instance.PlayBackgroundMusic(AppAudio.MUSIC_DND);
        }
        else if(sceneType == SceneType.Monke)
        {
            AudioManager.instance.PlayBackgroundMusic(AppAudio.MUSIC_MONKEY);
        }
    }
    public void LoadNextScene()
    {
        switch (nextScene)
        {
            case Scene.Monke:
                ScenesManager.scene = AppScenes.SESION_MONKEY;
                break;
            case Scene.Orc1:
                ScenesManager.scene = AppScenes.SESION_ORC_1;
                break;
            case Scene.Orc2:
                ScenesManager.scene = AppScenes.SESION_ORC_2;
                break;
            case Scene.Orc3:
                ScenesManager.scene = AppScenes.SESION_ORC_3;
                break;
            case Scene.Felon1:
                ScenesManager.scene = AppScenes.SESION_MUSKBOT_1;
                break;
            case Scene.Felon2:
                ScenesManager.scene = AppScenes.SESION_MUSKBOT_2;
                break;
            case Scene.Felon3:
                ScenesManager.scene = AppScenes.SESION_MUSKBOT_3;
                break;
            case Scene.DnD1:
                ScenesManager.scene = AppScenes.SESION_DND_1;
                break;
            case Scene.DnD2:
                ScenesManager.scene = AppScenes.SESION_DND_2;
                break;
            case Scene.DnD3:
                ScenesManager.scene = AppScenes.SESION_DND_3;
                break;
            case Scene.BTW1:
                ScenesManager.scene = AppScenes.WEEK_1_ORGANIZATION;
                break;
            case Scene.BTW2:
                ScenesManager.scene = AppScenes.WEEK_2_ORGANIZATION;
                break;
            case Scene.BTW3:
                ScenesManager.scene = AppScenes.WEEK_3_ORGANIZATION;
                break;
            case Scene.VICTORIA:
                ScenesManager.scene = AppScenes.SCENE_VICTORIA;
                break;
        }

        ScenesManager.LoadingScene();
    }
}