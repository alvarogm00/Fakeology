using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static DialogueObject;

public class DialogueViewer2 : MonoBehaviour
{
    public Transform parentOfResponses;
    [SerializeField] Image dNormal;
    [SerializeField] Image dFeliz;
    [SerializeField] Image dEnfadado;
    [SerializeField] Image dSorprendido;
    [SerializeField] Image iNormal;
    [SerializeField] Image iFeliz;
    [SerializeField] Image iEnfadado;
    [SerializeField] Image iSorprendido;

    [SerializeField] Button prefab_btnResponse;
    [SerializeField] TextMeshProUGUI txtMessage;
    [SerializeField] TextMeshProUGUI txtTitle;
    DialogueController controller;
    GameManager gM;

    void Start()
    {
        controller = GetComponent<DialogueController>();
        gM = FindObjectOfType<GameManager>();
        controller.onEnteredNode += OnNodeEntered;
        controller.InitializeDialogue();
    }

    private void OnNodeEntered(Node newNode)
    {
        CheckGoodOrBad(newNode);
        CheckEmotion(newNode);

        gM.nodeEntered = true;
        gM.numberOfChilds = 0;
        txtTitle.text = newNode.title;
        txtMessage.text = newNode.text; 
        KillAllChildren(parentOfResponses);

        int instantiatePosition = 0;
        for (int i = newNode.responses.Count - 1; i >= 0; i--)
        {
            var response = newNode.responses[i];
            int currentChoiceIndex = i;
            string buttonText;
            buttonText = response.displayText;

            //var responseButton = Instantiate(prefab_btnResponse, new Vector3(parentOfResponses.transform.position.x, parentOfResponses.transform.position.y - 100 + instantiatePosition, 0), Quaternion.identity, parentOfResponses);
            var responseButton = Instantiate(prefab_btnResponse);
            responseButton.transform.SetParent(parentOfResponses);
            responseButton.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
            responseButton.onClick.AddListener(delegate { OnNodeSelected(currentChoiceIndex); });
            //responseButtons[i].GetComponentInChildren<Text>().text = buttonText;
            //responseButtons[i].onClick.AddListener(delegate { OnNodeSelected(currentChoiceIndex); });

            instantiatePosition -= 60;
            gM.numberOfChilds++;
            //print(gM.numberOfChilds);
        }

        if (newNode.responses.Count <= 0)
        {
            gM.isLastNode = true;
        }
    }

    public static void KillAllChildren(UnityEngine.Transform parent)
    {
        UnityEngine.Assertions.Assert.IsNotNull(parent);
        for (int childIndex = parent.childCount - 1; childIndex >= 0; childIndex--)
        {
            UnityEngine.Object.Destroy(parent.GetChild(childIndex).gameObject);
        }
    }

    private void OnNodeSelected(int indexChosen)
    {
        controller.ChooseResponse(indexChosen);
    }

    void CheckGoodOrBad(Node newNode)
    {
        if (newNode.tags.Contains("MAL"))
        {
            gM.AffectPatiene(false);
        }
        else if (newNode.tags.Contains("BIEN"))
        {
            gM.AffectPatiene(true);
        }
    }

    void CheckEmotion(Node newNode)
    {
        if (newNode.tags.Contains("D.NORMAL"))
        {
            dNormal.gameObject.SetActive(true);
            dSorprendido.gameObject.SetActive(false);
            dFeliz.gameObject.SetActive(false);
            dEnfadado.gameObject.SetActive(false);
            if (gM.sceneType == GameManager.SceneType.Orc)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_ORC_1);
            }
            else if (gM.sceneType == GameManager.SceneType.Felon)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_ROBOT_1);
            }
            else if (gM.sceneType == GameManager.SceneType.Burro)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_DRAGON_1);
            }
            else if (gM.sceneType == GameManager.SceneType.Monke)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_MONKE_1);
            }
        }
        else if (newNode.tags.Contains("D.SORPRENDIDO"))
        {
            dNormal.gameObject.SetActive(false);
            dSorprendido.gameObject.SetActive(true);
            dFeliz.gameObject.SetActive(false);
            dEnfadado.gameObject.SetActive(false);
            if (gM.sceneType == GameManager.SceneType.Orc)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_ORC_2);
            }
            else if (gM.sceneType == GameManager.SceneType.Felon)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_ROBOT_2);
            }
            else if (gM.sceneType == GameManager.SceneType.Burro)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_DRAGON_2);
            }
            else if (gM.sceneType == GameManager.SceneType.Monke)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_MONKE_2);
            }
        }
        else if (newNode.tags.Contains("D.FELIZ"))
        {
            dNormal.gameObject.SetActive(false);
            dSorprendido.gameObject.SetActive(false);
            dFeliz.gameObject.SetActive(true);
            dEnfadado.gameObject.SetActive(false);
            if (gM.sceneType == GameManager.SceneType.Orc)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_ORC_3);
            }
            else if (gM.sceneType == GameManager.SceneType.Felon)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_ROBOT_3);
            }
            else if (gM.sceneType == GameManager.SceneType.Burro)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_DRAGON_3);
            }
            else if (gM.sceneType == GameManager.SceneType.Monke)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_MONKE_3);
            }
        }
        else if (newNode.tags.Contains("D.ENFADADO"))
        {
            dNormal.gameObject.SetActive(false);
            dSorprendido.gameObject.SetActive(false);
            dFeliz.gameObject.SetActive(false);
            dEnfadado.gameObject.SetActive(true);
            if (gM.sceneType == GameManager.SceneType.Orc)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_ORC_4);
            }
            else if (gM.sceneType == GameManager.SceneType.Felon)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_ROBOT_4);
            }
            else if (gM.sceneType == GameManager.SceneType.Burro)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_DRAGON_4);
            }
            else if (gM.sceneType == GameManager.SceneType.Monke)
            {
                AudioManager.instance.PlaySound(AppAudio.SOUND_MONKE_4);
            }
        }
        
        if (newNode.tags.Contains("I.NORMAL"))
        {
            iNormal.gameObject.SetActive(true);
            iSorprendido.gameObject.SetActive(false);
            iFeliz.gameObject.SetActive(false);
            iEnfadado.gameObject.SetActive(false);
        }
        else if (newNode.tags.Contains("I.SORPRENDIDO"))
        {
            iNormal.gameObject.SetActive(false);
            iSorprendido.gameObject.SetActive(true);
            iFeliz.gameObject.SetActive(false);
            iEnfadado.gameObject.SetActive(false);
        }
        else if (newNode.tags.Contains("I.FELIZ"))
        {
            iNormal.gameObject.SetActive(false);
            iSorprendido.gameObject.SetActive(false);
            iFeliz.gameObject.SetActive(true);
            iEnfadado.gameObject.SetActive(false);
        }
        else if (newNode.tags.Contains("I.ENFADADO"))
        {
            iNormal.gameObject.SetActive(false);
            iSorprendido.gameObject.SetActive(false);
            iFeliz.gameObject.SetActive(false);
            iEnfadado.gameObject.SetActive(true);
        }
    }
}
