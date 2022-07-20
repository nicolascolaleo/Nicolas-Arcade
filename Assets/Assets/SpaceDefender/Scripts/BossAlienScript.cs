using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlienScript : MonoBehaviour
{
    public Transform EnergyBallLeftSpawn, EnergyBallRightSpawn, EnergyBeamSpawn, SmallEnergyBeamLeftSpawn, SmallEnergyBeamRightSpawn;
    public GameObject BossHurt, EnergyBallPrefab, EnergyBeamLoadPrefab, EnergyBeamReleasePrefab, LeftSideBeamPrefab, RightSideBeamPrefab, BossExplosions, BossDefeatedConfsuedEffect;
    private GameObject Boss, player;
    private Animator anim;
    private Vector2 bossAwakePos;
    private float lerpTime = 0.0f;
    private float speed = 0.5f; // awake arrive speed
    private float normalMovementSpeed = 0.65f;
    private float fastMovementSpeed = 3.4f;
    private float superFastMovementSpeed = 6.8f;
    private float movementSpeed, randomDirection, enrageTimer, startMovingTimer, energyBallOrBeamTimer;
    private float startMovingTimerLimit = 2.5f;
    private float energyBallOrBeamTimerLimit = 1f;
    private int a;
    private bool BossAwakeningPos, afterawakeplayonce, isBossMoving, lockedToRight, lockedToLeft;
    public bool tryRespawnBallsAgain, tryRespawnEnergyBeam, tryRespawnSmallEnergyBeams, BossDefeated;

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Boss = GameObject.FindGameObjectWithTag("Boss");
        anim = GetComponent<Animator>(); 
        BossDefeated = false; 
        lockedToRight = false;  
        lockedToLeft = false;
        anim.enabled = false;   
        BossAwakeningPos = false;
        isBossMoving = false;
        tryRespawnBallsAgain = false;
        tryRespawnEnergyBeam = false;
        tryRespawnSmallEnergyBeams = false;
        afterawakeplayonce = false;
        bossAwakePos = new Vector2(0, 1.66f);
        lerpTime = speed * Time.fixedDeltaTime;
        randomDirection = 3f;
        movementSpeed = normalMovementSpeed;
    }

    void FixedUpdate()
    {
        if(BossAwakeningPos == false)
        {
            SpawnMoveToPosition();
            if(Boss.transform.position.y == 1.66f)
            {
                BossAwakeningPos = true;
                anim.enabled = true;            
            }
        }
        
        if(isBossMoving == false
            && BossAwakeningPos == true
            && afterawakeplayonce == false)
        {
            AfterSpawnPos();
        }
        
        if(isBossMoving == true
            && player != null
            && BossDefeated == false)
        {
            BossMovement();
        }
        
        if(player == null)
        {
            LookForPlayer();
        }

        if(tryRespawnBallsAgain == true 
            && tryRespawnEnergyBeam == true
            && tryRespawnSmallEnergyBeams == true
            && BossDefeated == false 
            && player != null)
        {   
            energyBallOrBeamTimer += Time.deltaTime;      
            if(energyBallOrBeamTimer >= energyBallOrBeamTimerLimit)
            {
                if(player.transform.position.x >= transform.position.x -0.6f
                && player.transform.position.x <= transform.position.x + 0.6f)
                {
                    a = 4;
                }
                else if(player.transform.position.x >= 3.35f
                        || player.transform.position.x <= -3.35f)
                {
                    a = Random.Range(4,6);
                }
                else
                {
                    a = Random.Range(1,6);
                   // Debug.Log("random attack is : " + a);
                }
                if(a == 1 || a == 3)
                {
                    //Debug.Log("energy ball " + a);
                    tryRespawnEnergyBeam = false;
                    tryRespawnBallsAgain = false;
                    tryRespawnSmallEnergyBeams = false;
                    isBossMoving = false;
                    StartCoroutine(EnergyBallCall());
                }
                else if(a == 4)
                {
                    //Debug.Log("energy beam " + a);
                    tryRespawnEnergyBeam = false;
                    tryRespawnBallsAgain = false;
                    tryRespawnSmallEnergyBeams = false;
                    isBossMoving = false;
                    StartCoroutine(EnergyBeamCall());
                }
                else if(a == 5)
                {
                    //Debug.Log("small energy beams " + a);
                    tryRespawnEnergyBeam = false;
                    tryRespawnBallsAgain = false;
                    tryRespawnSmallEnergyBeams = false;
                    isBossMoving = false;
                    StartCoroutine(SmallEnergyBeamsCall());
                }
                energyBallOrBeamTimer = 0;
            }

        }
    }

    private void SpawnMoveToPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, bossAwakePos, lerpTime);
    }

    private void AfterSpawnPos()
    {
        startMovingTimer += Time.deltaTime;      
        if(startMovingTimer >= startMovingTimerLimit)
        {
            isBossMoving = true;
            tryRespawnBallsAgain = true;
            tryRespawnEnergyBeam = true; 
            tryRespawnSmallEnergyBeams = true;
            afterawakeplayonce = true;
            anim.SetBool("isAwake", true);
        }
    }

    private void BossMovement()
    {

        if(player.transform.position.x > transform.position.x 
            && transform.position.x !> -1.6f
            && lockedToLeft == false)
        {
            transform.position +=  Vector3.left.normalized * (movementSpeed * Time.deltaTime);
        }
        else if(player.transform.position.x < transform.position.x 
                && transform.position.x !< 1.6f 
                && lockedToRight == false)
        {
            transform.position += Vector3.right.normalized * (movementSpeed * Time.deltaTime);
        }
        else if(player.transform.position.x == transform.position.x
                && transform.position.x > 1.45f
                && lockedToLeft == false)
        {
            transform.position +=  Vector3.left.normalized * (movementSpeed * Time.deltaTime);
        }
        else if(player.transform.position.x == transform.position.x
                && transform.position.x < -1.45f
                && lockedToRight == false)
        {
            transform.position += Vector3.right.normalized * (movementSpeed * Time.deltaTime);
        }
        else if(transform.position.x >= 1.55f || lockedToRight == true)
        {
            lockedToRight = true;
            transform.position += Vector3.left.normalized * (movementSpeed * Time.deltaTime);

        }
        else if(transform.position.x < -1.55f || lockedToLeft == true)
        {
            lockedToLeft = true;
            transform.position += Vector3.right.normalized * (movementSpeed * Time.deltaTime);

        }
        else if(player.transform.position.x == transform.position.x)
        {
            randomDirection = Random.Range(0,2);
            //Debug.Log(randomDirection);
            if(randomDirection == 1)
            {
                transform.position +=  Vector3.left.normalized * (movementSpeed * Time.deltaTime);
            }
            else if(randomDirection == 0)
            {
                transform.position +=  Vector3.right.normalized * (movementSpeed * Time.deltaTime);
            }
        }
        else if(player == null)
        {
            //Debug.Log("stop cause no player");
        }

        if(player.transform.position.x >= transform.position.x && lockedToRight == true)
        {
            lockedToRight = false;
        }
        if(player.transform.position.x <= transform.position.x && lockedToLeft == true)
        {
            lockedToLeft = false;
        }
    }

    private IEnumerator EnergyBallCall()
    { 
        if(BossDefeated == false)
        {
            //Debug.Log("started corotine");
            anim.SetBool("isChargingBalls", true);
            //Debug.Log("chargins balls");
            yield return new WaitForSeconds(1f);
            GameObject LeftEnergyBall = Instantiate(EnergyBallPrefab, EnergyBallLeftSpawn);
            GameObject RightEnergyBall = Instantiate(EnergyBallPrefab, EnergyBallRightSpawn);
            LeftEnergyBall.transform.parent = null;
            RightEnergyBall.transform.parent = null;
            yield return new WaitForSeconds(1.2f);
            anim.SetBool("isChargingBalls", false);
            isBossMoving = true;
            yield return new WaitForSeconds(2f - enrageTimer);
            tryRespawnBallsAgain = true;  
            tryRespawnEnergyBeam = true;  
            tryRespawnSmallEnergyBeams = true;     
        }
        else
        {
            yield break;
        }
    }

    private IEnumerator EnergyBeamCall()
    {
        movementSpeed = fastMovementSpeed;
        anim.SetBool("isChargingBeam", true);
        gameObject.GetComponent<PolygonCollider2D>().offset = new Vector2(0, 0.21f);

        if(transform.position.x !> -1.55f || transform.position.x !< 1.55f 
            && BossDefeated == false)
            {
                if(player == null)
                {
                    do
                    {
                        LookForPlayer();
                        yield return null;
                    }
                    while(player == null);
                }
                if(player.transform.position.x > transform.position.x + 0.6f)
                {
                    do
                    {
                        transform.position +=  Vector3.right.normalized * (movementSpeed * Time.deltaTime);
                        yield return null;
                        if(BossDefeated == true)
                        {
                            transform.position = new Vector2(0, transform.position.y - 0.4f);
                            break;
                        }
                    }
                    while(transform.position.x <= 4.5f);
                }

                else if(player.transform.position.x < transform.position.x -0.6f)
                {
                    do
                    {
                        transform.position +=  Vector3.left.normalized * (movementSpeed * Time.deltaTime);
                        yield return null;
                        if(BossDefeated == true)
                        {
                            transform.position = new Vector2(0, transform.position.y - 0.4f);
                            break;
                        }
                    }
                    while(transform.position.x >= -4.5f);
                }
                else if(BossDefeated == true)
                {
                    yield break;
                }
                else
                {
                   // Debug.Log("dont stay infront");
                }
            }
        if(BossDefeated == false)
        {
            Instantiate(EnergyBeamLoadPrefab, EnergyBeamSpawn);
            yield return new WaitForSeconds(0.875f);
            anim.SetBool("isChargingBeam", false);
            anim.SetBool("isBeamReleased", true);
            yield return new WaitForSeconds(0.375f);
            gameObject.GetComponent<PolygonCollider2D>().offset = new Vector2(0,0);
            movementSpeed = superFastMovementSpeed; 
            Instantiate(EnergyBeamReleasePrefab, EnergyBeamSpawn);

            if(transform.position.x > 4.0f)
            {
                do
                {
                    transform.position +=  Vector3.left.normalized * (movementSpeed * Time.deltaTime);
                    yield return null;
                    if(BossDefeated == true)
                    {
                        transform.position = new Vector2(0, transform.position.y - 0.4f);
                        break;
                    }
                }
                while(transform.position.x >= -3.5f);
            }

            else if(transform.position.x < -4.0f)
            {
                do
                {
                    transform.position +=  Vector3.right.normalized * (movementSpeed * Time.deltaTime);
                    yield return null;
                    if(BossDefeated == true)
                    {
                        transform.position = new Vector2(0, transform.position.y - 0.4f);
                        break;
                    }
                }
                while(transform.position.x <= 3.5f);
            }

            yield return new WaitForSeconds(2f);
            movementSpeed = normalMovementSpeed;
            anim.SetBool("isBeamReleased", false);
            if(BossDefeated == true)
            {
               yield break;
            }
            GameObject.FindObjectOfType<BeamDestroyOnCall>().DestroyOnCall();
            yield return new WaitForSeconds(0.5f);
            isBossMoving = true;
            yield return new WaitForSeconds(2f - enrageTimer);
            tryRespawnBallsAgain = true;  
            tryRespawnEnergyBeam = true;  
            tryRespawnSmallEnergyBeams = true;  
        }
        else
        {
            yield break;
        }
    }

    private IEnumerator SmallEnergyBeamsCall()
    {
        movementSpeed = fastMovementSpeed;
        anim.SetBool("isChargingSmallBeams", true);
        if(player == null)
        {
            do
            {
                LookForPlayer();
                yield return null;
            }
            while(player == null);

        }
        else if(BossDefeated == true)
        {
            yield break;
        }
        if(transform.position.x != 0)
        {
            do
            {
                transform.position =  Vector3.MoveTowards(transform.position, new Vector2(0, transform.position.y), movementSpeed * Time.deltaTime);
                yield return null;
            }
            while(transform.position.x != 0f);
        }
        else if(BossDefeated == true)
        {
            yield break;
        }
        if(BossDefeated == false)
        {   
            yield return new WaitForSeconds(1.2f);
            anim.SetBool("isChargingSmallBeams", false);
            anim.SetBool("isReleasingSmallBeams", true);
            Instantiate(LeftSideBeamPrefab, SmallEnergyBeamLeftSpawn);
            Instantiate(RightSideBeamPrefab, SmallEnergyBeamRightSpawn);
            yield return new WaitForSeconds(2f);
            anim.SetBool("isReleasingSmallBeams", false);
            movementSpeed = normalMovementSpeed;
            isBossMoving = true;
            yield return new WaitForSeconds(2f - enrageTimer);
            tryRespawnBallsAgain = true;  
            tryRespawnEnergyBeam = true;  
            tryRespawnSmallEnergyBeams = true;  
        }
        else
        {
            yield break;
        }
    }

    private void LookForPlayer()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "projectile" 
            && BossAwakeningPos == true 
            && BossDefeated == false)
        {
            Instantiate(BossHurt, transform.position, transform.rotation, gameObject.transform);
            GameObject.FindObjectOfType<BossHealthSliderEffect>().CallBossHealthBar();
        }
        if(other.gameObject.tag == "projectile" 
            && gameObject.GetComponent<Animator>().GetBool("isChargingBeam") == true
            && BossDefeated == false)
        {
            Instantiate(BossHurt, new Vector2 (transform.position.x, transform.position.y + 0.21f), transform.rotation, gameObject.transform);
            GameObject.FindObjectOfType<BossHealthSliderEffect>().CallBossHealthBar();
        }
    }
    public void EnrageTime()
    {
        enrageTimer = 0.8f;
        normalMovementSpeed += (enrageTimer*2); //0.65f is base
        fastMovementSpeed += (enrageTimer*2);//3.4f is base
        superFastMovementSpeed += (enrageTimer*2); //6.8f is base
        anim.SetBool("isBossEnraged", true);
    }

    public void BossDefeat()
    {
        StartCoroutine(BossDefeatEffect());
    }

    private IEnumerator BossDefeatEffect()
    {
        BossDefeated = true;
        tryRespawnBallsAgain = false;
        tryRespawnEnergyBeam = false;
        tryRespawnSmallEnergyBeams = false;
        isBossMoving = false;
        transform.position = new Vector2(0, transform.position.y - 0.4f);
        Instantiate(BossDefeatedConfsuedEffect, new Vector2(transform.position.x + 0.8f, transform.position.y + 0.4f), transform.rotation, gameObject.transform);
        anim.SetBool("isBossDefeated", true);
        int a = 0;
        do
        {
            float x = Random.Range(-2.3f, 2.3f);
            float y = Random.Range(0.2f ,2.15f);
            Vector2 ExplosionPos = new Vector2(x, y);
            Instantiate(BossExplosions, ExplosionPos, transform.rotation, gameObject.transform);
            yield return new WaitForSeconds(0.02f);
            a++;
        }
        while(a < 445);
        GameObject.FindObjectOfType<ReloadEffects>().Flashbang();
        Destroy(gameObject, 0.1f);
        
        GameObject.FindObjectOfType<ParralaxStarsPrefabScript>().ChildrenEnableAnim();
    }
}
