using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class BW_DragDropObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas m_canvas;

    private RectTransform rectTransform;
    //private Vector2 screenBounds;

    private void Awake()
    {
        rectTransform = this.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) //Se llama cuando empezamos a arrastrar.
    {
        AudioManager.instance.PlaySound(AppAudio.SOUND_LEFT_OBJECT);
    }

    public void OnDrag(PointerEventData eventData) //Se llama cada Frame mientras estamos arrastrando el objeto en cuestión.
    {
        //Movimiento delta. Lo que se ha movido el ratón desde el frame anterior. Si lo añadimos el objeto se mueve con el ratón. La escala del canvas para movimiento exacto.
        rectTransform.anchoredPosition += eventData.delta/m_canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData) //Se llama cuando paramos de arrastrar.
    {
        AudioManager.instance.PlaySound(AppAudio.SOUND_TAKE_OBJECT);
    }
}
