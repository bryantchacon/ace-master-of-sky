using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributesExample : MonoBehaviour
{
    //COMO BUENA PRACTICA LOS ATRIBUTOS VAN ARRIBA DE LAS VARIABLES/FUNCIONES A LAS QUE SE APLICAN

    [Space] //Agrega un espacio en el editor
    [Header("Ints")] //Agrega un header de seccion en el editor, seguido de un espacio automaticamente
    public int score;
    [SerializeField] //Muestra en el editor una variable privada
    private int money;

    [Space]
    [Header("Other values")]
    [SerializeField]
    private string password;
    [HideInInspector] //No muestra en el editor una variable publica
    public int numbersRand;

    [Space]
    [Header("Sliders")]
    [Range(0, 5)] //Crea una variable slider entre los valores que se indiquen, la variable puede ser int o float
    public int lifes;
    [SerializeField]
    [Min(0)] //Indica que el valor minimo de la variable sea el que se indica, la variable puede ser int o float
    private float numberRand;

    [Space]
    [Header("Texts")]
    public string playerName;
    [TextArea] //Crea un area te texto amplia para escribir un parrafo
    public string dialogue;

    [Header("Tools")]
    [Tooltip("ID del player, modificar con cuidado")] //Muestra el texto que se ponga como un tip en el editor cuando el mouse se pone encima del nombre de la variable
    [SerializeField]
    private string ID;
    [ContextMenu("Call MyFunction")] //Permite llamar la funcion desde el editor al estar ejecutandose el juego, esto desde el menu de tres puntos del script, el texto entre comillas es el nombre con el que aparecera
    public void MyFunction()
    {
        Debug.Log("MyFunction fue ejecutada");
    }

    public Player player;
}
//Por medio de los parametros del constructor de una clase se pasan los valores que tendran las variables de esa clase
[System.Serializable] //Permite visualizar el contenido de otra clase dese el editor, esto en conjuto con una variable del mismo tipo en la clase principal de este script, que en este caso es la variable player
public class Player
{
    public int playerId;
    public string playerName;
}