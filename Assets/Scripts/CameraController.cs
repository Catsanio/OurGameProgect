using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    [Range(0, 1)] private float smoothspeed = 0.125f;
    private Vector3 offset;


    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (target)transform.position = Vector3.Lerp(transform.position,target.position + offset, smoothspeed);
    }
}
