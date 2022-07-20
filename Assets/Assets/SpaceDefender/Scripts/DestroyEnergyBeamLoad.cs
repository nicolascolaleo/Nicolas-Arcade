using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnergyBeamLoad : MonoBehaviour
{
    private void Start() 
    {
        transform.position = new Vector2(transform.position.x -0.034f, transform.position.y + 0.287f);
    }
    private void FixedUpdate() 
    {
        Destroy(gameObject, 0.875f);
    }
}
