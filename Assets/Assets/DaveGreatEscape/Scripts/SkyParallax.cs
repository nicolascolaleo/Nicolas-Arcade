using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyParallax : MonoBehaviour
{
    Vector2 currentPos;
    void Start()
    {
        currentPos = transform.position;
    }
    void FixedUpdate()
    {
        currentPos.x += 0.009f;
        transform.position = currentPos;
       if(transform.position.x > 32.67f)
       {
           transform.position = new Vector2(-33.19f, 0);
           currentPos = transform.position;
       }
    }
}
