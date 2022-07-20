using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform Pos1, Pos2;
    public float Speed;
    public Transform StartPos;
    Vector3 nextPos;

    public bool isScreenMoving = false;

    void Start() 
    {
        nextPos = StartPos.position;
    }
    void Update()
    {
        if(isScreenMoving == false)
        {
            MovingPlatform();
        }
    }

    void MovingPlatform()
    {
        if(transform.position == Pos1.position)
        {
            nextPos = Pos2.position;
        }
        if(transform.position == Pos2.position)
        {
            nextPos = Pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, Speed * Time.deltaTime);
    }
}
