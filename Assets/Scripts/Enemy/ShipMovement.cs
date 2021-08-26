using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Libreria de DOTween

public class ShipMovement : MonoBehaviour
{
    public Ease ease; //Variable donde se elegira que ease usara el barco

    private void Start()
    {
        transform.DOMoveX(0, 2).SetEase(ease); //DOMoveX es una funcion de DOTween que indica que el game object se mueva de donde esta al punto 0 en X en 2 segundos y .SetEase es para indicar que ease usara
    }
}