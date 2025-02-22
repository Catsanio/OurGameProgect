using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovmentScript : MonoBehaviour
{
    public float moveSpeed = 5f,health;
    public GameObject pickUpText, portalText;
    public Transform weaponPoint;
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed;
        transform.position += movement * Time.deltaTime;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag ("Weapon"))
        {
            pickUpText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Transform curWeapon = collision.transform;
                curWeapon.position = weaponPoint.position;
                curWeapon.SetParent(weaponPoint);
                curWeapon.rotation = weaponPoint.rotation;
                curWeapon.tag = "Untagged";
                pickUpText.SetActive(false);
            }
        }    
        if(collision.CompareTag("Portal"))
        {
            portalText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            pickUpText.SetActive(false);
        }
    }
    
}
