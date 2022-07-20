using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerScript : MonoBehaviour
{
    public GameObject BossPrefab;
    public void SpawnBoss()
    {
        Instantiate(BossPrefab, transform.position, transform.rotation);
        Destroy(gameObject, 1.0f);
    }
}
