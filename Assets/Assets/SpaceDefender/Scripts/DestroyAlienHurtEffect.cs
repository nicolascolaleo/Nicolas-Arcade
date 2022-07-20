using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAlienHurtEffect : MonoBehaviour
{
    private void FixedUpdate() 
    {
        Destroy(gameObject, 0.1f);
    }
}
