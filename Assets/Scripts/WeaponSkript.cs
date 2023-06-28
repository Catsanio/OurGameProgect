using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponSkript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed;
    [SerializeField] private int CurAmmo, Ammo, MaxAmmo, CurMaxAmmo;
    [SerializeField] private TextMeshProUGUI ammoText;
    // Start is called before the first frame update
    private void Start()
    {
        CurAmmo = Ammo;
        CurMaxAmmo = CurAmmo;
        FillText();
    }
    private void Reload()
    {
        if (CurMaxAmmo > Ammo)
        {
            CurAmmo = Ammo;
            CurMaxAmmo -= Ammo;
        }
        else
        {
            CurAmmo = CurMaxAmmo;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
    }
    private void Shoot()
    {
        GameObject curBulet = Instantiate(bulletPrefab, firePoint.position,
            Quaternion.identity);
        curBulet.GetComponent<Rigidbody2D>().AddForce(-transform.right *
            bulletSpeed);
        Destroy(curBulet, 1f);
        CurAmmo--;
        FillText();
        if (Ammo <= 0)
        {
            Reload();
        }

    }
    private void FillText()
    {
        ammoText.text = CurAmmo - 1 + "/" + CurMaxAmmo;
    }
}
