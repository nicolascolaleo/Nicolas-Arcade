using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinalWinAnim : MonoBehaviour
{
    private Animator anim;
    public GameObject ResetOrQuitAnim;
    float timer = 0.667f;
    private bool playOnce;
    
    private void Awake() 
    {
        playOnce = true;
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <=0 && playOnce == true)
        {
            Instantiate(ResetOrQuitAnim, new Vector2(0,-3), transform.rotation);
            playOnce = false;
            anim.SetBool("isSecondPart", true);
        }
    }
}