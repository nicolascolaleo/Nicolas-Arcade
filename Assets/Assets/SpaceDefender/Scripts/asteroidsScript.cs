using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidsScript : MonoBehaviour
{
    float asteroidSpeed, rotation;
     private void Awake() 
    {
       rotation = RandomRotationSpeed();
       asteroidSpeed = RandomAsteroidSpeed();
       
    }
    void Update()
    {
        transform.Rotate(0 , 0, rotation);
        transform.position += new Vector3(0, asteroidSpeed * Time.deltaTime);
         if(transform.position.y <= -5.75f)
       {
           Destroy(this.gameObject);
       }
    }

    private float RandomRotationSpeed()
    {
    if(Random.Range(0,2) == 1)
        {
            return -0.15f;
        }
            else
        {
            return 0.15f;
        }
    }

     private float RandomAsteroidSpeed()
    {
    if(Random.Range(0,2) == 1)
        {
            return -0.6f;
        }
            else
        {
            return -1.1f;
        }
    }
}