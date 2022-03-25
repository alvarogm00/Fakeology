using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GenerateRandomSentence : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string[] frasesSemanales = new string [20] { "Atento al indicador de granada.",
        "Acuerdate de recargar antes de disparar.", "Si caminas vas a ir mas lento que cuando corres.",
        "Si tu equipo no gana, pierde.", "Un subfusil es como un fusil pero con sub.", "Si tu salud llega a cero moriras.",
        "Los carros sirven para transportarte a diferentes lugares.", "Si te curas recuperaras vida.", "Cuidado con las granadas que explotan.",
        "Usa el lanzacohetes para lanzar cohetes.", "Soy el comandante Shepard y esta es mi tienda favorita de la ciudadela.",
        "The cake is a lie.", "Camello tactico. Encima tactico. Heavy MACHINEGUN.", "Lo siento crak la princesa esta en otro castillo. Mastodonte. Figura. Titan.",
        "Todas tus bases nos pertenecen.", "ALL WE HAD TO DO WAS FOLLOW THE DAMN TRAIN CJ!", "Esto... Esto no es un juego.", "Tira iniciativa.",
        "Mira detras de ti, UN MONO DE TRES CABEZAS", "Juega al Don't shoot the messenger."};

    void Start()
    {
        int randonNum = Random.Range(0, frasesSemanales.Length);
        text.text = frasesSemanales[randonNum];
    }

}
