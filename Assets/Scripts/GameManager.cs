using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //Libreria para poder usar los Action

public class GameManager : MonoBehaviour
{
    public delegate void PlayerDeath(); //1/4 Delegado, guarda una o mas funciones, al igual que una variable puede ser privado o publico, para poder hacerlo primero se debe instanciar
    public static event PlayerDeath OnPlayerDeath; //2/4 Instancia del delegado

    public GameObject gameOverScreen;

    public static Action OnUpdateScore; //Un action es una version mas simple de un delegado, comprime su creacion y su instancia en una sola linea de codigo

    private void OnEnable()
    {
        OnUpdateScore += UpdateScoreUI;
    }

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        OnPlayerDeath += ShowGameOverScreen; //3/4 Se agrega una funcion mas(por el +) al delegado
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void PlayerKilled()
    {
        OnPlayerDeath?.Invoke(); //4/4 Con ? pregunta si contiene alguna funcion, si las hay las invoca TODAS
    }

    public void UpdateScoreUI()
    {
        //TODO: Cambiar el valor del score en la UI
        Debug.Log("Score actualizado");
    }
}