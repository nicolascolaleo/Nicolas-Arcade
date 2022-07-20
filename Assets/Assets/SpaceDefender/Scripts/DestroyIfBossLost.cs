using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfBossLost : MonoBehaviour
{
    private void Update() 
    {
        if(GameObject.FindObjectOfType<BossAlienScript>().BossDefeated == true)
        {
            Destroy(gameObject);
        }
    }
}
