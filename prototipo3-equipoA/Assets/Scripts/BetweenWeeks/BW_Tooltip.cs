using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class BW_Tooltip : MonoBehaviour
{
    [SerializeField] private Camera m_uiCamera;

    private TextMeshProUGUI m_tooltipText;
    private RectTransform m_backgroundRectTransform;
    private static BW_Tooltip instance;


    private void Awake()
    {
        instance = this;

        m_backgroundRectTransform = transform.Find("Fondo").GetComponent<RectTransform>();
        m_tooltipText = transform.Find("Text").GetComponent<TextMeshProUGUI>();

        ShowTooltip("Sentarse en la oscuridad y escuchar mi ASMR favorito sin distracciones.");
    }

    private void Update()
    {
        //Convertimos la posicion del raton a la posicón posicion en este padre

        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(), Input.mousePosition, m_uiCamera, out localPoint);

        transform.localPosition = localPoint;
    }


    private void ShowTooltip(string tooltipString)
    {
        this.gameObject.SetActive(true);

        //Ajustamos el fondo al texto.
        m_tooltipText.text = tooltipString;
        float textPaddingSize = 4f;
        Vector2 backgroundSize = new Vector2(m_tooltipText.preferredWidth + textPaddingSize * 2, m_tooltipText.preferredHeight + textPaddingSize * 2);
        m_backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideToolTip()
    {
        this.gameObject.SetActive(false);
    }


    //Funciones publicas estaticas que podemos usar en otras partes del codigo.
    public static void ShowTooltip_Static(string tooltipString)
    {
        instance.ShowTooltip(tooltipString);
    }

    public static void HideTooltip_Static()
    {
        instance.HideToolTip();
    }
}
