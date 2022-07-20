using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileMovement : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(0, 3 * Time.deltaTime, 0));
        if(transform.position.y >= 5.75f)
        {
           Destroy(this.gameObject);
        }
    }
}
