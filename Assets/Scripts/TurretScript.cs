using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f, bulletSpeed;

    private Transform player;
    private float fireCountdown = 0f;

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Запуск пострілів з моменту старту
        fireCountdown = 10f / fireRate;
        InvokeRepeating("Shoot", 3f,1 / fireRate);
    }

    private void Update()
    {
        // Визначення напрямку до гравця
        Vector2 direction = player.position - transform.position;

        // Обчислення кута обертання до гравця
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 180;

        // Обертання турелі до гравця
        //Quaternion rotation = Quaternion.Euler(angle, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Логіка пострілів
        //if (fireCountdown <= 0f)
        
            //Shoot();
            //fireCountdown = 1f / fireRate;
        

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        // Створення снаряду та вистріл
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(-transform.right *
            bulletSpeed);
    }
}
