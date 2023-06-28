using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyBrain : MonoBehaviour
{

    public float moveSpeed = 3f;

    private Transform player;
    public float Hp;
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
        if (Hp >= 0)
        {
            //Destroy(Instantiate(EnemyDieAnimation), 1f);
            Destroy(player);
            Destroy(rb);

        }
    }
    //Знімання хп при попадані кулі по ворогу
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "BulletFriend")
        {
            Hp--;
            Destroy(collision.gameObject);
        }
    }
}
