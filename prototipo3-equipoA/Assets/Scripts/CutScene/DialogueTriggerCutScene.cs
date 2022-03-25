using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerCutScene : MonoBehaviour
{

    public DialogueCutScene dialogueCutScene;

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(dialogueCutScene);
    }
}
