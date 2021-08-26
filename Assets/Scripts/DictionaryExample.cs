using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryExample : MonoBehaviour
{
    public Dictionary<string, string> dictionary = new Dictionary<string, string>(); //Diccionario inicializado, la primer variable es la key y la segunda el valor de la key, la key y el valor pueden ser de diferentes tipos de datos
    public Dictionary<string, PlayerData> playersDictionary = new Dictionary<string, PlayerData>(); //Diccionario de players. NOTA: Tambien se pueden guardar objetos/clases/game objects enteros

    void Start()
    {
        //Agrega keys y sus valores al diccionario
        dictionary["Avion"] = "Aeronave de ala fija"; //Agrega al diccionario la key Avion, y su valor es Aeronave de ala fija
        dictionary["Barco"] = "Construccion que flota y navega en el agua";
        dictionary["Mar"] = "Cuerpo de agua salada";

        dictionary.TryGetValue("Avion", out string value); //Extrae el valor de una key del diccionario y lo guarda(por out) en una variable local(value) de la instruccion
        Debug.Log(value); //Imprime en consola el valor guardado en value

        //foreach que recorre los valores del diccionario
        foreach (string item in dictionary.Values) //Se usa .Values para indicar que lo que recorrera seran los valores del diccionario, no los keys
        {
            Debug.Log(item);
        }

        //Se crean y agregan players al diccionario de players
        playersDictionary["PedroElPro"] = new PlayerData("Pedro", 10);
        playersDictionary["JMaster"] = new PlayerData("Juan", 100);

        //foreach que recorre el diccionario de players. NOTA: Se pueden recorrer objetos/clases/game objects enteros
        foreach (PlayerData player in playersDictionary.Values) //El item player es de tipo  PlayerData porque se recorrera cada player del diccionario y...
        {
            Debug.Log(player.name); //Se imprimira en consola el nombre de cada uno
        }
    }
}

public class PlayerData //Clase player
{
    public string name;
    public int score;

    public PlayerData(string playerName, int playerScore) //Constructor de la clase, con el que se podra crear nuevas instancias de la clase. NOTA: Sus parametros seran el valor de las variables de la clase
    {
        name = playerName;
        score = playerScore;
    }
}