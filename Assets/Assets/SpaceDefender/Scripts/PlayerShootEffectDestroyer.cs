using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootEffectDestroyer : MonoBehaviour
{
    private void FixedUpdate() 
    {
        Destroy(gameObject, 0.133f);
    }
}
