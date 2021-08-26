using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hola soy un mensaje"); //Log de mensaje sencillo
        Debug.LogWarning("La ejecucion del codigo casi termina"); //Log de aviso
        Debug.LogError("ERROR MUNDIAL"); //Log de error, pausa el codigo hasta donde esta

        for (int i = 0; i < 10; i++)
        {
            Debug.LogFormat($"<color = blue> {i} </color>"); //Debug personalizado con un breakpoint
        }
    }
}