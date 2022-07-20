using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidsSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefab;
    private int respawnTime;
    void Awake()
    {
        StartCoroutine(asteroidWave());
    }
    void Update()
    {
        respawnTime = RandomRespawnTime();
    }
    private void spawnAsteroid()
    {
       GameObject a = Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)], this.transform);
        a.transform.position = new Vector2(Random.Range(-4.18f, 4.18f), 7.4f);
    }
    IEnumerator asteroidWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnAsteroid();
            if(GameObject.FindObjectOfType<CountDownTimer>().StopShootingAndAsteroids == true)
            {
                while (gameObject.transform.childCount > 0)
                {
                    foreach (Transform child in gameObject.transform)
                    {
                        gameObject.transform.DetachChildren();
                    }
                }
                Destroy(gameObject);
            }
        }
    }

    private int RandomRespawnTime()
    {
    int a = Random.Range(5, 15);
    return a;
    }

}
