using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawner : MonoBehaviour
{
    public GameObject AlienPrefab;
    private float spawnInTime;
    private int start = 1; 
    private bool stopSpawnUpdateOnce;
    void Start()
    {
            stopSpawnUpdateOnce = true;
            StartCoroutine(alienWave());
    }
    void Update()
    {
        if(GameObject.FindObjectOfType<CountDownTimer>().BossTime == false)
        {
            spawnInTime = RandomRespawnTime();
        }
        
        if(GameObject.FindObjectOfType<CountDownTimer>().BossTime == true && stopSpawnUpdateOnce == true)
        {
            StopCoroutine(alienWave());
            //Debug.Log("stopped spawning aliens");
            stopSpawnUpdateOnce = false;
        }
    }
    private void spawnAlien()
    {
        int mask1 = LayerMask.GetMask("AlienLayer");
        float radius = 1f;
        int retrySpawn = 0;
        while(retrySpawn++ < 10)
        {
            float x = Random.Range(-4.35f, 4.2f);
            float y = Random.Range(0.4f ,2.75f);
            Vector2 alienPos = new Vector2(x, y);
        
            Collider2D CollisionWithEnemy = Physics2D.OverlapCircle(alienPos, radius, mask1);
            if (CollisionWithEnemy == false && GameObject.FindObjectOfType<LifePointScript>().TotalLife > 0)
            {
                Instantiate(AlienPrefab, alienPos, transform.rotation);
                return;
            }
        
            //Debug.Log("can't spawn here" + alienPos);
        }
    }
    IEnumerator alienWave()
    {
        
        while(true)
        {
        if(start == 1)
            {
                yield return new WaitForSeconds(10);
                if(GameObject.FindObjectOfType<CountDownTimer>().BossTime == true)
                {
                    break;
                }
                spawnAlien();
                start--;
            }
        else
            {
                yield return new WaitForSeconds(spawnInTime);
                if(GameObject.FindObjectOfType<CountDownTimer>().BossTime == true)
                {
                    break;
                }
                spawnAlien();
            }
           // Debug.Log("spawning in.. " + spawnInTime);
        }           
    }
    private float RandomRespawnTime()
    {
    if(GameObject.FindObjectOfType<CountDownTimer>().currentTime <= 130f
        && GameObject.FindObjectOfType<CountDownTimer>().currentTime >= 90f)
        {
         spawnInTime = 10f;
        }
    else if(GameObject.FindObjectOfType<CountDownTimer>().currentTime <= 90f
        && GameObject.FindObjectOfType<CountDownTimer>().currentTime >= 25f)
        {
            spawnInTime = 5.5f;   
        }
    else if(GameObject.FindObjectOfType<CountDownTimer>().currentTime <= 25f
        && GameObject.FindObjectOfType<CountDownTimer>().currentTime >= 1f)
        {
            spawnInTime = 3f;               
        }
    return spawnInTime;
    }

}
