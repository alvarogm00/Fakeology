using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveVariables : PersistenSingleton<SaveVariables>
{
    private float suspicion;

    public float Suspicion
    {
        get
        {
            return suspicion;
        }

        set
        {
            suspicion = value;
        }
    }
}
