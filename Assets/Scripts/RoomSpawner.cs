using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental;
using UnityEngine;
public enum Direction
{
    None,
    Top,
    Bottom,
    Left,
    Right
}
public class RoomSpawner : MonoBehaviour
{
    public Direction direction;


    public RoomChoice choice;
    private bool spawned = false;
    private float waitTime = 3f;
    private void Start()
    {
        choice = FindObjectOfType<RoomChoice>();
       
        Invoke("Spawn", 0.2f);
    }
    private void Update()
    {
        Invoke("Spawn", 0.2f);
    }
    public void Spawn()
    {
        if (spawned) return;

        switch (direction)
        {
            case Direction.Top:
                spawned = true;
                break;
            case Direction.Right:
                spawned = true;
                break;
            case Direction.Left:
                spawned = true;
                break;
            case Direction.Bottom:
                spawned = true;
                break;
        }
        spawned = true;
   }
    
}
