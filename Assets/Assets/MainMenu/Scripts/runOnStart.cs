using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class runOnStart : MonoBehaviour
{
    public GameObject spaceDefenders;
    void Start()
    {
        SpaceDefendersScreen();        
    }


    private void SpaceDefendersScreen()
    {
        Instantiate(spaceDefenders, Vector3.zero, Quaternion.identity);
        Destroy(gameObject);
    }

}
