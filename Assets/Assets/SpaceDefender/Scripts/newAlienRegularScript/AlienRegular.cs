using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienRegular : MonoBehaviour
{
    public GameObject ExplodeOnDeath, AlienShoot, AlienHurt;
    public AudioClip AlienShootSFX;
    private Animator anim;
    int AlienHealth = 5;
    private float timeToMove, timePerMovement, timePerAttack, timeToAttack;
    private bool deSpawnOnce,shootOnce;
    Vector2 right = new Vector2(0.3f,0);
    Vector2 left = new Vector2(-0.3f,0);
    private void Start()
    {
        anim = GetComponent<Animator>(); 
        timePerMovement = 0;
        timePerAttack = 0;
        deSpawnOnce = false;
        shootOnce = true;
        StartCoroutine(isAlienSpawned());
    }
    void Update()
    {
        if(anim.GetBool("isAlienMovingNormally") == true)
        {
            AlienMovement();
            if(timePerAttack == 0 
                && GameObject.FindObjectOfType<LifePointScript>().TotalLife > 0
                && shootOnce == true)
            {
                shootOnce = false;
                StartCoroutine(AlienAggro());
            }
        }
        if(GameObject.FindObjectOfType<CountDownTimer>().BossTime == true
            && deSpawnOnce == false)
        {
            deSpawnOnce = true;
            StartCoroutine(DespawnEffect());
        }
    }
     private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "projectile")
        {
            AlienHurtEffect();
            AlienHealth--;
            if(AlienHealth == 0)
            {
                Destroy(gameObject);
                Instantiate(ExplodeOnDeath, transform.position, transform.rotation);
            }
        }
    }

    private void AlienHurtEffect()
    {
        Instantiate(AlienHurt, transform.position, transform.rotation, gameObject.transform);
    }
    private IEnumerator isAlienSpawned()
    {
       // Debug.Log("hello");
        yield return new WaitForSeconds(0.429f); 
        anim.SetBool("isAlienMovingNormally", true);
    }


        private IEnumerator AlienAggro()
    {
        if(AlienHealth < 2)
        {
            timeToAttack = Random.Range(0.5f,1);
        }
        else if(AlienHealth < 3)
        {
            timeToAttack = Random.Range(1,1.5f);
        }
        else
        {
            timeToAttack = Random.Range(1.5f,2.5f);
        }
            yield return new WaitForSeconds(timeToAttack);
            anim.SetBool("isAlienChargingShoot", true);
            yield return new WaitForSeconds(0.667f); 
            anim.SetBool("isAlienChargingShoot", false);
            anim.SetBool("isAlienShoot", true);
            yield return new WaitForSeconds(0.4f);
            Instantiate(AlienShoot, new Vector2(transform.position.x, transform.position.y - 0.7f) ,transform.rotation, gameObject.transform);
            SoundManager.instance.PlaySFX(AlienShootSFX);
            anim.SetBool("isAlienShoot", false);
            anim.SetBool("isAlienMovingNormally", true);
            timePerAttack = 0;
            shootOnce = true;
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
    private IEnumerator DespawnEffect()
    {
         anim.SetBool("isAlienDespawned", true);
         yield return new WaitForSeconds(0.429f);
         Destroy(gameObject);
    }
}
