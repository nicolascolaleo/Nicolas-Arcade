using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendPower : MonoBehaviour
{
    private float fallSpeed = -0.7f;

    void Update()
    {
        transform.position += new Vector3(0, fallSpeed * Time.deltaTime);
         if(transform.position.y <=  -4.8f)
       {
           Destroy(this.gameObject);
       }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {

            Destroy(gameObject);
        }
    }
}
