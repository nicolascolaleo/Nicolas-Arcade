using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScroller : MonoBehaviour
{
    private Animator anim;
    public float ParralaxSpeed;
    private bool checkSpeedOnce;
    private void Awake() 
    {
        checkSpeedOnce = false;
        ParralaxSpeed = -2f;
        anim = GetComponent<Animator>();
        anim.enabled = false;        
    }
    void FixedUpdate()
    {
        if(checkSpeedOnce == false
            && GameObject.FindObjectOfType<CountDownTimer>().BossTime == true)
        {
            
            if(ParralaxSpeed <-0.7f)
            {
                ParralaxSpeed+= 0.5f * Time.fixedDeltaTime;
               // Debug.Log(ParralaxSpeed);
            }
            else
            {
                checkSpeedOnce = true;
               // Debug.Log("finished " + ParralaxSpeed);
            }

        }
        ParralaxEffect();
    }

    private void ParralaxEffect()
    {
        transform.position += new Vector3(0, ParralaxSpeed * Time.deltaTime);

       if(transform.position.y <= -15.36f)
       {
           transform.position = new Vector3(transform.position.x, 19.9f);
       }
    }
    private void IncreaseParralaxSpeedEffect()
    {
        ParralaxSpeed+= -2f;
    }
    public void EnablePallaxAnim()
    {
        anim.enabled = true;
    }
}
