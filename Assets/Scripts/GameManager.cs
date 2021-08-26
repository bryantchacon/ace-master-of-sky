using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void PlayerDeath(); //Delegado, guarda una o mas funciones, al igual que una variable puede ser privado o publico, para poder hacerlo primero se debe instanciar
    public static event PlayerDeath OnPlayerDeath; //Instancia del delegado

    public GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        OnPlayerDeath += ShowGameOverScreen; //Se agrega una funcion mas(por el +) al delegado
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void PlayerKilled()
    {
        OnPlayerDeath?.Invoke(); //Con ? pregunta si contiene alguna funcion, si las hay las invoca TODAS
    }
}