using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer; //Referencia el propio sprite renderer del fade en el editor

    [ContextMenu("Fade In")] //Muestra la funcion en los tres puntos del componente de este script en el editor
    public void FadeIn()
    {
        spriteRenderer.DOFade(1, 2).OnComplete(()=>
        {
            Debug.Log("Fade In Completo");
        }); //DOFade es una funcion de DoTween que vuelve transparente(0) o revierte una transparencia(1) en determinado tiempo, en este caso en 2 segundos y .OnComplete es para concatenar una funcion anonima al completarse el fade in, la cual se escribe(entre {}) o llama(sin {}) aqui mismo
    }

    [ContextMenu("Fade Out")]
    public void FadeOut()
    {
        spriteRenderer.DOFade(0, 2).OnComplete(()=> StartGame()).OnStart(()=>
        {
            Debug.Log("Fade Out Iniciado");
        }); //Al iniciar el fade out imprime el debug log en consola y al completarse ejecuta la funcion StartGame
    }

    private void StartGame()
    {
        Debug.Log("Fade Out completo");
    }

    private void Start()
    {
        FadeOut(); //Desactiva el fade en cuanto se inicia el juego
        GameManager.OnPlayerDeath += FadeIn; //Agrega la funcion FadeIn al delegado OnPlayerDeath del GameManager. NOTA: No se usa FindObjectOfType porque esto esta en el Start
    }
}