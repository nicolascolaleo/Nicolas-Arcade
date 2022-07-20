using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosionDestroyer : MonoBehaviour
{
    private void FixedUpdate() 
    {
        Destroy(gameObject, 0.150f);
    }
}
