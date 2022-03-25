using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class BW_DragDropPossit : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [Header("Poner Día de la Semana")]
    [Tooltip("Debe coincidir con el string del día de la semana en cuestión. Sino poner - .")]
    public string m_diaSemana;

    [Header("Introducir tarea que pone en el possit")]
    [Multiline] public string m_tarea;

    [HideInInspector] public GameObject m_ultimoDiaSemanaDejado;

    [Header("Otras variables")]
    [SerializeField] private Canvas m_canvas;
    [SerializeField] private GameObject m_possitParent;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = this.GetComponent<RectTransform>();
        canvasGroup = this.GetComponent<CanvasGroup>();
        m_ultimoDiaSemanaDejado = null;
    }

    private void Start()
    {
        BW_Tooltip.HideTooltip_Static();
    }

    public void OnBeginDrag(PointerEventData eventData) //Se llama cuando empezamos a arrastrar.
    {
        //Para que el raycast atraviese este objeto e impacto con el que lo vamos a colocar.
        canvasGroup.blocksRaycasts = false;

        //Utilizamos la referencia al último día de la semana para cotejar cosas. 
        if (m_ultimoDiaSemanaDejado != null && eventData.pointerDrag.transform.parent == m_ultimoDiaSemanaDejado.transform) //Si su padre es el ultimo día de la semana.
        {
            //Le cambiamos de GO padre al del possit.
            eventData.pointerDrag.transform.SetParent(m_possitParent.transform);

            //Además indicamos que el slot ya esta libre y se puede poner otro possit.
            BW_PossitWeekSlot ultimoDiaDejado = m_ultimoDiaSemanaDejado.GetComponent<BW_PossitWeekSlot>();
            ultimoDiaDejado.m_slotOcupada = false;

            //Quitamos 1 possit de la cuenta total de la semana.
            BW_WeekManager.Instance.AñadirPossitSemana(false);

            //Comprobamos si los días coincidian. Si lo hacian, le restamos el acierto que le habiamos dado.
            if (ultimoDiaDejado.m_diaCorrespondienteSemana == m_diaSemana)
            {
                BW_WeekManager.Instance.m_numeroDeAciertos -= 1;
                Debug.Log("NUMERO TOTAL ACIERTOS   " + BW_WeekManager.Instance.m_numeroDeAciertos);
            }
        }
    }

    public void OnDrag(PointerEventData eventData) //Se llama cada Frame mientras estamos arrastrando el objeto en cuestión.
    {
        //Movimiento delta. Lo que se ha movido el ratón desde el frame anterior. Si lo añadimos el objeto se mueve con el ratón. La escala del canvas para movimiento exacto.
        rectTransform.anchoredPosition += eventData.delta/m_canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData) //Se llama cuando paramos de arrastrar.
    {
        canvasGroup.blocksRaycasts = true;
    }


    public void OnPointerEnter(PointerEventData eventData) //se llama cuando el cursor entra el area de este elemento.
    {
        BW_Tooltip.ShowTooltip_Static(m_tarea);
    }

    public void OnPointerExit(PointerEventData eventData) //se llama cuando el cursor sale el area de este elemento.
    {
        BW_Tooltip.HideTooltip_Static();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.instance.PlaySound(AppAudio.SOUND_TAKE_POSSITS);
    }
}
