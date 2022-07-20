using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyReadySetGo : MonoBehaviour
{
    private void FixedUpdate() 
    {
       Destroy(gameObject, 2.333f); 
    }
}
