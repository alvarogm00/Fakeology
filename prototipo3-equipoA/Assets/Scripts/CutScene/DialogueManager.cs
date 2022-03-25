using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    public GameObject botonPress;
    public GameObject imagenPress;
    public GameObject textoPress;
    public GameObject nombrePress;
    public GameObject panelPress;

    public GameObject textoDopple;
    public GameObject nombreDopple;
    public GameObject panelDopple;

    public GameObject audioNews;

    public static DialogueManager Instance
    {
        get;
        private set;
    }

    public void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        sentences = new Queue<string>();

        AudioManager.instance.MusicVolume = 1;
        AudioManager.instance.PlayBackgroundMusic(AppAudio.MUSIC_CUT_SCENE);
    }

    public void StartDialogue (DialogueCutScene dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }


    void EndDialogue()
    {
        botonPress.SetActive(false);
        imagenPress.SetActive(false);
        textoPress.SetActive(false);
        nombrePress.SetActive(false);
        panelPress.SetActive(false);

        textoDopple.SetActive(true);
        nombreDopple.SetActive(true);
        panelDopple.SetActive(true);

        audioNews.SetActive(false);
    }

}
