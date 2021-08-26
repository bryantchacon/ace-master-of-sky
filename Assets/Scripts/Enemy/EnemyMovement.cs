using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D enemyRb;
    public float enemySpeed;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        enemyRb.velocity = (target.position - transform.position).normalized * enemySpeed; //Para que el enemigo o cualquier cosa persiga al player se divide la posicion del player entre la del enemigo, osea la posicion de destino menos en la que esta ahora, se normaliza(lo cual da 1) para que se mueva a una velocidad constante, se multiplica por su velocidad y todo esto se asigna como la velocidad del enemigo en el FixedUpdade por medio de su rigid body
    }
}