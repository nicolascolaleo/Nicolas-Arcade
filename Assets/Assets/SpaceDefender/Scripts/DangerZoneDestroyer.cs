using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZoneDestroyer : MonoBehaviour
{
    private void FixedUpdate() 
    {
        Destroy(gameObject, 3.8f);
    }

}
