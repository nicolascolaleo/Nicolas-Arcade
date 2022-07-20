using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStartTransitionEffect : MonoBehaviour
{
    private void FixedUpdate() 
    {
        Destroy(gameObject, 1.056f);
    }
}
