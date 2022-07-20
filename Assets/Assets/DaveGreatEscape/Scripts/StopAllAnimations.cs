using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAllAnimations : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameObject.Find("ScreenTransfer").GetComponent<MoveScreenScript>().ChangeToNextScreen == true)
        {
            anim.speed = 0;
        }
        else if(GameObject.Find("ScreenTransfer").GetComponent<MoveScreenScript>().ChangeToNextScreen == false)
        {
            anim.speed = 1;
        }
    }
    
}
