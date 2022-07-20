using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExplosionDestroyer : MonoBehaviour
{
    private void FixedUpdate() 
    {
        Destroy(gameObject, 0.556f);
    }
}
