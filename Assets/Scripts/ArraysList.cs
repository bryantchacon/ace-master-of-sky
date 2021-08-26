using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArraysList : MonoBehaviour
{
    //Arrays: Son fijos, osea no se pueden modificar una vez se esta ejecutando el codigo, y almacenan de datos del mismo tipo
    public int[] numbers = new int[2]; //Array inicializado que empieza con 2 espacios, se pueden agregar mas, pero solo antes de iniciar el juego en el editor
    public int[] count; //Array no inicializado, no tiene ningun espacio al aparecer en el editor

    //List: Son dinamicas y pueden agrandarse segun se requiera aunque el codigo este en ejecucion
    public List<string> names = new List<string>(); //Lista de strings, siempre hay que inicializarla

    void Start()
    {
        //foreach que recorre el array count
        foreach (int item in count) //Bucle foreach, se lee: Por cada item(variable local del bucle, debe ser del mismo tipo de cada elemento en la coleccion o del dato del elemento que se valla a extraer de el) en count...
        {
            Debug.Log(item); //Imprime cada item en la consola
        }

        //Agregando datos a la lista
        names.Add("Pablo");
        names.Add("Pedro");
        names.Add("Anita");
        names.Remove("Pedro");

        //foreach que recorre la lista names
        foreach (string item in names)
        {
            Debug.Log(item);
        }
    }
}