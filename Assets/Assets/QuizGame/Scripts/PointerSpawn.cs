using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerSpawn : MonoBehaviour
{
    public GameObject PointerAnim;
    Vector2 PointerPos = new Vector2(-4.5f, 2.5f);
    void Awake()
    {
        Instantiate(PointerAnim, PointerPos, transform.rotation);
        Destroy(gameObject);
    }
}
