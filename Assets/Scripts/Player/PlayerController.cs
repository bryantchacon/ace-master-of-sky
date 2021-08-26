using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Libreria del Input System para poder usar el InputValue(se le pone nombre como una variable) en la funcion OnMove

[RequireComponent(typeof(Rigidbody2D))] //Agrega automaticamente un Rigidbody2D(o cualquier componente que se indique) al game object al que se añada este script
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float movementX;
    private float movementY;
    private float speed;
    public float minSpeed;
    public float maxSpeed;
    public float rotationSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //rb es igual a un componente que yo tengo el cual es un Rigidbody2D
    }

    private void OnMove(InputValue movementValue) //OnMove es una funcion autoejecutable para detectar el movimiento del player debido al paquete Input System, el componente Player Input agregado al player, y el Input Action Asset creado y agregado en el mismo componente. Funciona automaticamente porque se le pasa por parametro el InputValue(se le pone nombre como una variable) del Input System
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); //Se obtiene y guarda el Vector2 del imput value
        movementX = movementVector.x; //Se asigna el valor de cada vector a la variable correspondiente
        movementY = movementVector.y;
    }

    private void FixedUpdate() //FixedUpdade esta optimizado para el movimiento de assets
    {
        //Movimiento con las flechas del teclado
        //rb.velocity = new Vector2(movementX, movementY) * speed; //Se multiplica por speed para que el player vaya mas rapido

        //Avance automatico y giro con las flechas izquierda y derecha
        rb.rotation -= movementX * rotationSpeed; //.rotation es para indicar la rotacion de un game object por medio de su rigid body, ahora la deteccion de movimiento en "x" por la velocidad de rotacion, sera el movimiento de rotacion del player
        speed = Mathf.Clamp(speed + movementY, minSpeed, maxSpeed); //La de movimiento en "y" es para acelerar o desacelerar, limitandolo entre un min y un max, y al iniciar el juego empieza en el minimo
        rb.velocity = transform.up * speed; //Al iniciar el juego el player empieza moviendose hacia arriba SOBRE SU EJE POSITIVO "y" sin importar si esta rotado, a la velocidad que detecte en speed
    }
}