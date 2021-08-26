using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TernaryOp : MonoBehaviour
{
    public int a;
    public int b;

    void Start()
    {
        string suma = a == b ? "Son iguales" : "No son iguales"; //Operador ternario, compara dos variables y contiene las opciones a dar si se cumple o no, todo esto en la misma linea de codigo, sustituye un if con su else, se lee: "a" es igual a "b"?, si lo es, "Son iguales" seguarda en la variable suma, si no, "No son iguales"
        Debug.Log(suma);
    }
}
