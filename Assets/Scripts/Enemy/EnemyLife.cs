using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private void OnEnable() //OnEnable es una funcion de unity para ejecutar lo que contenga en cuanto se HABILITA el game object que contenga el script
    {
        //GameManager.OnUpdateScore += Deactivate; //NOTA: NO ACTIVAR, SI NO, TODOS LOS ENEMIGOS SE DESACTIVAN AL ELIMINAR UNO SOLO
    }

    private void OnDisable()
    {
        GameManager.OnUpdateScore.Invoke();        
    }

    public GameObject explosion; //Referencia el prefab de la explosion en el editor

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject exp = Instantiate(explosion); //Primero se instancia la explosion por aparte en una variable
            exp.transform.position = transform.position; //Se indica que la posicion donde aparecera sera la del enemigo en ese momento
            Deactivate(); //Y se desactiva el enemigo
            
            //Como todo esto se ejecuta al instante pasa asi: El enemigo se desactiva, la explosion se reproduce, y se destruye automaticamente al terminar por que asi esta configurado en su animacion
        }
        else if (collision.CompareTag("Missile"))
        {
            GameObject exp = Instantiate(explosion);
            exp.transform.position = transform.position;
            Deactivate();
            //TODO: Y agregarlo a la lista de object pool
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}