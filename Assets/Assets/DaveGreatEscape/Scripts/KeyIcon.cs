using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyIcon : MonoBehaviour
{
    public void IsKeyUsed()
    {
        Destroy(gameObject, 0.3f);
    }
}
