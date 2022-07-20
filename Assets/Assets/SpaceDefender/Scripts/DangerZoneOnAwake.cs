using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZoneOnAwake : MonoBehaviour
{
    public GameObject dangerZone;
    void Awake()
    {
        Instantiate(dangerZone, new Vector2(0,2.3f), transform.rotation);
        Destroy(gameObject);
    }

}
