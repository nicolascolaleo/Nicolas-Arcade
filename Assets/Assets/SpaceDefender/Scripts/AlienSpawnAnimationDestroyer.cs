using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnAnimationDestroyer : MonoBehaviour
{
    private void FixedUpdate() 
    {
        Destroy(gameObject, 0.429f);
    }
} 

