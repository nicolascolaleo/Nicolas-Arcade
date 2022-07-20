using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidBallSpawner : MonoBehaviour
{
    public GameObject AcidBall;

    void Awake()
    {
        StartCoroutine(AcidBalls());
    }

    private void SpawnAcidBall()
    {
        Instantiate(AcidBall, transform.position, Quaternion.identity);
    }

    IEnumerator AcidBalls()
    {
        while(true)
        {
            yield return new WaitForSeconds(5);
            SpawnAcidBall();
        }
    }
}
