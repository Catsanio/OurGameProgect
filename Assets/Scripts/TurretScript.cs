using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 10f, bulletSpeed;

    private Transform player;
    private float fireCountdown = 0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Запуск пострілів з моменту старту
        fireCountdown = 1f / fireRate;
    }

    private void Update()
    {
        // Визначення напрямку до гравця
        Vector2 direction = player.position - transform.position;

        // Обчислення кута обертання до гравця
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Обертання турелі до гравця
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        // Логіка пострілів
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

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
