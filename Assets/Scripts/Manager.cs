using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    private void Start()
    {
        transform.GetChild(LevlManager.level - 1).gameObject.SetActive(true);
    }
}
