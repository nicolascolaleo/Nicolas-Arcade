using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class LoadingScreenScript : MonoBehaviour
{
    public GameObject loadingScreen;
    void Awake()
    {
       Instantiate(loadingScreen, Vector3.zero, Quaternion.identity);
    }

}
