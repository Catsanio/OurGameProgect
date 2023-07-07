using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyBrain : MonoBehaviour
{

    public float moveSpeed = 3f;
    private float timebtwAttack;
    public float startTimebtwAttack;
    public Transform playerpos;
    public float hp,damage;
    public Animator anim;
    private Rigidbody2D rb;
    public MovmentScript player;

    private void Start()
    {
        
        player = FindObjectOfType<MovmentScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Визначення напрямку руху до гравця
        Vector2 direction = playerpos.position - transform.position;

        // Рух ворога в напрямку гравця
        rb.velocity = direction.normalized * moveSpeed;
        if (hp <= 0)
        {
            Destroy(gameObject);
            
        }
    }
    //Знімання хп при попадані кулі по ворогу
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            anim.SetBool("Attack",true);
        }
        else
        {
            timebtwAttack -= Time.deltaTime;
        }
        if (collision.transform.tag == "BulletFriend")
        {
            hp-=2;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.SetBool("Attack", false);
        }
        else
        {
            timebtwAttack -= Time.deltaTime;
        }
    }
    public void OnEnemyAttack()
    {
        
        player.health -= damage;
        timebtwAttack = startTimebtwAttack;
    }
}
