using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MissileBehaviour : MonoBehaviour
{
    private Rigidbody2D missileRb;
    public float missileSpeed;

    private void Start()
    {
        missileRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() //Aqui se pone todo lo que tenga que ver con animacion de sprites
    {
        missileRb.velocity = transform.up * missileSpeed; //Aplica velocidad al eje Y positivo del missil
    }
}