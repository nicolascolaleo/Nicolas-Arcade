using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesSpawner : MonoBehaviour
{
    public GameObject NewLeafPrefab;
    private bool newSummon;
    private float waitUntilNewSummon;

    void Awake() 
    {
        newSummon = true;
    }
    void Update()
    {
        if(newSummon == true)
        {
            waitUntilNewSummon = RandomSummonTime();
            StartCoroutine(NewLeafSpawn());
        }
    }
    private float RandomSummonTime()
    {
        float newSummonTime = Random.Range(3, 9);
        return newSummonTime;
    }
    private IEnumerator NewLeafSpawn()
    {
        newSummon = false;
        float x = Random.Range(9.7f, 14.85f);
        float y = Random.Range(2.45f ,4.0f);
        Vector2 leafPos = new Vector2(x, y);

        Instantiate(NewLeafPrefab, leafPos, transform.rotation);
        yield return new WaitForSeconds(waitUntilNewSummon);
        newSummon = true;
    }
}
