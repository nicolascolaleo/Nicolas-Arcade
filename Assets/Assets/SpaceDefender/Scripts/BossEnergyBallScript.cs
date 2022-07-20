using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnergyBallScript : MonoBehaviour
{
    private GameObject player;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 playerPos;
    private float speed = 4.4f;
    private float startMovingTimer;
    private float startMovingTimerLimit = 1.35f;

    void Start()
    {
        startMovingTimer = 0f;
        player = GameObject.FindWithTag("Player"); 
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        anim.SetBool("AfterSpawnEnd", true);
    }
    private void Update() 
    {
        startMovingTimer += Time.deltaTime;      
        if(startMovingTimer >= startMovingTimerLimit)
        {
            TargetPlayerPos();
        }

    }

    private void TargetPlayerPos()
    {      
        if(player != null)
        {
            if(player.transform.position.y <= gameObject.transform.position.y)
            {
                playerPos = new Vector3(player.transform.position.x, player.transform.position.y - 1.0f, player.transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            }
            else
            {
                transform.position +=  new Vector3(player.transform.position.x, transform.position.y, transform.position.z).normalized * (speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position +=  transform.position.normalized * (speed * Time.deltaTime);
        }

        if(transform.position.y <= -5.75f || transform.position.y >= 5.75f || transform.position.x >= 10.0f || transform.position.x <= -10.0f)
        {
           Destroy(this.gameObject);
        }  
    }
}
