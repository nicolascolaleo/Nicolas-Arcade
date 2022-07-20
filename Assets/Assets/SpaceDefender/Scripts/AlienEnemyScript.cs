using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienEnemyScript : MonoBehaviour
{
    public Transform AlienNormal;
    public GameObject AlienHurt, explosion, AlienAttack, AlienShoot, DeSpawnAlien;
    public AudioSource AlienShootSFX;
    int AlienHealth = 4;
    private float timeToMove;
    private float timePerMovement = 0;
    private float timePerAttack = 0;
    private float timeToAttack;
    Vector2 right = new Vector2(0.3f,0);
    Vector2 left = new Vector2(-0.3f,0);
    void Update()
    {
        AlienMovement();
        AlienAggro();
                if(GameObject.FindObjectOfType<CountDownTimer>().BossTime == true)
                {
                    DestroyOnBossTime();
                }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "projectile")
        {
            (Instantiate(AlienHurt, AlienNormal.position, transform.rotation)).transform.parent = AlienNormal.transform;
            AlienHealth--;
            if(AlienHealth == 0)
            {
                Destroy(gameObject);
                Instantiate(explosion, AlienNormal.position, transform.rotation);
            }
        }
    }

    private void AlienAggro()
    {
        if(AlienHealth < 2)
        {
            timeToAttack = Random.Range(1,3);
        }
        else if(AlienHealth < 3)
        {
            timeToAttack = Random.Range(3,5);
        }
        else
        {
            timeToAttack = Random.Range(4,6);
        }
        timePerAttack += Time.deltaTime;
        if(timePerAttack > timeToAttack && GameObject.FindObjectOfType<LifePointScript>().TotalLife > 0)
        {
            (Instantiate(AlienAttack, AlienNormal.position, transform.rotation)).transform.parent = AlienNormal.transform;
            AlienShootSFX.Play();
            timePerAttack = 0;
            (Instantiate(AlienShoot,new Vector2(AlienNormal.transform.position.x, AlienNormal.transform.position.y - 0.7f),AlienNormal.transform.rotation)).transform.parent = AlienNormal.transform;
            
        }

    }

    private void AlienMovement()
    {  
        int RightOrLeft = Random.Range(0,2);
        if(AlienHealth < 3)
        {
            timeToMove = 0.5f;
        }
        else if(AlienHealth < 4)
        {
            timeToMove = 1f;
        }
        else
        {
            timeToMove = 1.5f;
        }

        timePerMovement += Time.deltaTime;
        
        if(timePerMovement > timeToMove)
        {
            if(RightOrLeft == 0)
            {
                transform.Translate(left);
                timePerMovement = 0;
            //    Debug.Log("move left");
            
            if(transform.position.x <= -4.16f)
            {
                transform.Translate(right);
                transform.Translate(right);
                timePerMovement = 0;
            //    Debug.Log("moved right cause limit");
            }
            }
            else
            {
                transform.Translate(right);
                timePerMovement = 0;
            //    Debug.Log("move right");
                
                if(transform.position.x >= 4.16f)
                {
                    transform.Translate(left);
                    transform.Translate(left);
                    timePerMovement = 0;
            //    Debug.Log("moved left cause wall");
                }
            }
        }  
    }

    public void DestroyOnBossTime()
    {
            Destroy(gameObject);
            Instantiate(DeSpawnAlien, AlienNormal.position, transform.rotation);       
    }
}







/*
TEST
 private void AlienMovement()
    {  
        int RightOrLeft = Random.Range(0,2);
        if(AlienHealth < 3)
        {
            timeToMove = 0.5f;
        }
        else if(AlienHealth < 4)
        {
            timeToMove = 1f;
        }
        else
        {
            timeToMove = 1.5f;
        }

        timePerMovement += Time.deltaTime;
        
        if(timePerMovement > timeToMove)
        {
            if(RightOrLeft == 0 
                && GameObject.FindObjectOfType<LeftDetector>().IsLeftDetected == false)
            {
                transform.Translate(left);
            //    Debug.Log("move left");
                if(transform.position.x <= -4.16f 
                    && GameObject.FindObjectOfType<LeftDetector>().IsLeftDetected == false)
                {
                    transform.Translate(right);
                    transform.Translate(right);
                    timePerMovement = 0;
                //    Debug.Log("moved right cause limit");
                }
                else if (transform.position.x <= -4.16f 
                && GameObject.FindObjectOfType<LeftDetector>().IsLeftDetected == true)
                {
                    timePerMovement = 0;
                }
            timePerMovement = 0;
            }

            else if(RightOrLeft == 1 
                && GameObject.FindObjectOfType<RightDetector>().IsRightDetect == false)
            {
                transform.Translate(right);
            }
                if(transform.position.x >= 4.16f 
                    && GameObject.FindObjectOfType<RightDetector>().IsRightDetect == false)
                {
                    transform.Translate(left);
                    transform.Translate(left);
                    timePerMovement = 0;
                //    Debug.Log("moved right cause limit");
                }
                else if (transform.position.x >= 4.16f 
                && GameObject.FindObjectOfType<RightDetector>().IsRightDetect == true)
                {
                    timePerMovement = 0;
                }
            timePerMovement = 0;
        }  
    }*/