using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class BW_PossitWeekSlot : MonoBehaviour, IDropHandler
{
    [Header("Poner día de la semana en cuestión.")]
    [Tooltip("Debe coindidir exactamente con el día del possit deseado.")]
    public string m_diaCorrespondienteSemana;

    [HideInInspector] public bool m_slotOcupada = false; //Variable que indica si ya tiene un possit.


    public void OnDrop(PointerEventData eventData) //Cuando el objeto se le deja encima.
    {
        if (eventData.pointerDrag != null && !m_slotOcupada) //Si hay un GO que actualmente se está arrastrando. Y la casilla está libre. 
        {
            eventData.pointerDrag.transform.SetParent(this.transform);
            m_slotOcupada = true;
            BW_WeekManager.Instance.AñadirPossitSemana(true); //Añadimos 1 y comprobamos si están los 7 puestos.

            //Comprobamos si tiene el script possit.
            BW_DragDropPossit possit = eventData.pointerDrag.GetComponent<BW_DragDropPossit>();

            //El script possit guarda una referencia al ultimo día de la semana donde estubo para al quitarlo de este (si lo hacemos) pueda referenciar cosas,
            possit.m_ultimoDiaSemanaDejado = this.gameObject;

            if (possit)
            {
                if(possit.m_diaSemana == m_diaCorrespondienteSemana) //si lo tiene comprobamos si conincide con el día que lo ha puesto.
                {
                    //Si lo hace sumamos a la variable singleton temporal de al scena +1 acierto.
                    BW_WeekManager.Instance.m_numeroDeAciertos += 1;
                    Debug.Log("NUMERO TOTAL ACIERTOS   " + BW_WeekManager.Instance.m_numeroDeAciertos);
                }
                else
                {
                    //Si no no hacemos nada. Los aciertos no suben (minimo de 0 máximo de 7).
                    Debug.Log("Incorrecta +0");
                    Debug.Log("NUMERO TOTAL ACIERTOS   " + BW_WeekManager.Instance.m_numeroDeAciertos);
                }
            }
        }
    }  
}
