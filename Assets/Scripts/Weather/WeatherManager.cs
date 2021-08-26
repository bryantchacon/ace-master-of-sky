using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //Libreria para agregar un networking
using LitJson; //Libreria para convertir la respuesta de la API en un JSON, se puede usar una vez agregado el LitJSON.dll en el proyecto

public class WeatherManager : MonoBehaviour
{
    private int actualWeather;

    [SerializeField]
    DigitalRuby.RainMaker.RainScript2D rainMaker; //Se referencia desde el editor. NOTA: No se puede iniciar en el start, asi que cada que se quiera usar su script se usa el GetComponent<>

    private void Start()
    {
        StartCoroutine(GetWeather()); //Llama la corrutina al iniciar el juego        
    }

    IEnumerator GetWeather() //IEnumerator(corrutina) que consultara el clima a la API de Open Weather
    {
        UnityWebRequest weather = UnityWebRequest.Get("api.openweathermap.org/data/2.5/weather?q=Tapachula&appid=52694f2062b39aa5458e066b2cac345f"); //Variable tipo UnityWebRequest que consulta y guarda el clima por medio de la API call(string entre comillas), donde dice Tapachula va la ciudad del clima a consultar y los numeros del final son la API key
        yield return weather.SendWebRequest(); //Espera a que se envie una respuesta de la consulta
        
        if (weather.result != UnityWebRequest.Result.Success) //Si el resultado del clima no es Success...
        {
            Debug.LogError(weather.error); //Imprime en consola el error que el clima envie
            actualWeather = 800;
        }
        else //Si no, si envio una respuesta satisfactoria...
        {
            JsonData jsonData = JsonMapper.ToObject(weather.downloadHandler.text); //Convierte la respuesta de la API en un JSON y lo guarda en la variable
            actualWeather = (int)jsonData["weather"][0]["id"]; //Obtiene el valor del clima actual de la respuesta de la API convertida en JSON, de la seccion weather, del primer objeto, el cual debe ser(coincidir con lo que se escriba) id y lo guarda en la variable
        }

        Debug.Log("Weather condition ID: " + actualWeather); //Imprime el valor del clima actual
        WeatherChanger(); //Invoca la funcion para cambiar el clima dependiendo del numero del actualWeather
        StopCoroutine(GetWeather()); //Detiene esta misma corrutina
    }

    private void WeatherChanger()
    {
        if (actualWeather >= 200 && actualWeather < 300)
        {
            //Tormenta
            rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 1;
        }
        else if (actualWeather >= 300 && actualWeather < 400)
        {
            //Llovizna
            rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 0.2f;
        }        
        else if (actualWeather >= 500 && actualWeather < 600)
        {
            //Lluvia
            rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 0.5f;
        }        
        else if (actualWeather == 800)
        {
            //Despejado
            rainMaker.gameObject.SetActive(false);
        }
        else if (actualWeather > 800)
        {
            //Nublado
            rainMaker.GetComponent<DigitalRuby.RainMaker.RainScript2D>().RainIntensity += 0.1f;
        }
    }
}