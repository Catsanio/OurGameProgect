using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{

    public float moveSpeed = 3f;

    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Визначення напрямку руху до гравця
        Vector2 direction = player.position - transform.position;

        // Рух ворога в напрямку гравця
        rb.velocity = direction.normalized * moveSpeed;
    }
}
