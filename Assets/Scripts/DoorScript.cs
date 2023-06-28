using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator _animator;
    public bool isLocked;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLocked)
        {
            _animator.SetBool("Open", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _animator.SetBool("Open", false);
        }
    }
}
