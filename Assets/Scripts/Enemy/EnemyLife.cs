using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public GameObject explosion; //Referencia el prefab de la explosion en el editor

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject exp = Instantiate(explosion); //Primero se instancia la explosion por aparte en una variable
            exp.transform.position = transform.position; //Y se indica que la posicion donde aparecera sera la del enemigo en ese momento
            Destroy(gameObject); //Y se destruye el enemigo
            //Como esto se ejecuta al instante pasa asi: El enemigo se destruye, la explosion se reproduce y se destruye automaticamente por que su animacion lo indica al terminar
        }
    }
}