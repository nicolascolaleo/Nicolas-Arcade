using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Animator anim;
    public GameObject Player;
    public Transform RespawnPoint;
    private bool isCheckPointOn = false;

    private void Awake() 
    {
        anim = GetComponent<Animator>();     
        anim.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player") && isCheckPointOn == false)
        {
            anim.enabled = true;
            isCheckPointOn = true;
            RespawnPoint.transform.position = new Vector2(36.87f, -3.464f);
        }
    }
}
